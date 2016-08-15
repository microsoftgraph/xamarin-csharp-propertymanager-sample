/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using XamarinNativePropertyManager.Extensions;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public class GraphService : IGraphService
    {
        private readonly IHttpService _httpService;

        private readonly IAuthenticationService _authenticationService;

        public string Resource => "https://graph.microsoft.com/beta/";

        public GraphService(IHttpService httpService,
            IAuthenticationService authenticationService)
        {
            _httpService = httpService;
            _authenticationService = authenticationService;
        }

        public async Task EnsureTokenIsPresentAsync()
        {
            var authenticationResult = await GetAuthenticationResultAsync();
            _httpService.Resource = new Uri(Resource);
            _httpService.GetRequestHeaders().Authorization = new AuthenticationHeaderValue("Bearer",
                authenticationResult.AccessToken);
        }

        private async Task<AuthenticationResult> GetAuthenticationResultAsync()
        {
            AuthenticationResult authenticationResult;
            try
            {
                // Try to get the tokens silently.
                authenticationResult = await _authenticationService.AcquireTokenSilentAsync();
                return authenticationResult;
            }
            catch
            {
                // Ignored.
            }

            // Prompt the user.
            authenticationResult = await _authenticationService.AcquireTokenAsync();
            return authenticationResult;
        }

        private async Task<T> GetOneAsync<T>(string resource) where T : class
        {
            return await SendAsync<T>(resource, HttpMethod.Get);
        }

        private async Task<T[]> GetManyAsync<T>(string resource)
        {
            return (await SendAsync<ResponseModel<T>>(resource, HttpMethod.Get)).Value;
        }

        private async Task<T> PostAsync<T>(string resource, T data) where T : class
        {
            return await SendAsync(resource, HttpMethod.Post, data);
        }

        public async Task<T> PutAsync<T>(string resource, T data) where T : class
        {
            return await SendAsync(resource, HttpMethod.Put, data);
        }

        public async Task<T> PutAsync<T>(string resource, Stream stream, string contentType) where T : class
        {
            return await SendAsync<T>(resource, HttpMethod.Put, stream, contentType);
        }

        private async Task<T> PatchAsync<T>(string resource, T data) where T : class
        {
            return await SendAsync(resource, HttpMethod.Patch, data);
        }

        private async Task<T> SendAsync<T>(string resource, HttpMethod httpMethod, T data) where T : class
        {
            var str = JsonConvert.SerializeObject(data, Constants.JsonSerializerSettings);
            using (var stream = str.GetStream())
            {
                return await SendAsync<T>(resource, httpMethod,
                    stream, Constants.JsonContentType);
            }
        }

        private async Task<T> SendAsync<T>(string resource, HttpMethod httpMethod, Stream stream = null, string contentType = null) where T : class
        {
            // Try to do the call without calling ADAL. This reduces the 
            // execution time of this call drastically.
            try
            {
                if (_httpService.GetRequestHeaders().Authorization == null)
                {
                    await EnsureTokenIsPresentAsync();
                }
                return await _httpService.SendAsync<T>(resource, httpMethod, stream, contentType);
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message != "Unauthorized")
                {
                    throw;
                }
            }

            // Call ADAL to validate tokens.
            try
            {
                await EnsureTokenIsPresentAsync();
                return await _httpService.SendAsync<T>(resource, httpMethod, stream, contentType);
            }
            catch
            {
                // Ignored.
            }
            return default(T);
        }

        public Task<UserModel> GetUserAsync()
        {
            return GetOneAsync<UserModel>("me/");
        }

        public Task<GroupModel[]> GetUserGroupsAsync()
        {
            // Expanding the total amount of groups to the maximum (999).
            return GetManyAsync<GroupModel>("me/memberOf?$top=999");
        }

        public Task<DriveItemModel[]> GetUserDriveItemAsync()
        {
            return GetManyAsync<DriveItemModel>("me/drive/special/approot/children?select=id,name");
        }

        public Task<DriveItemModel> AddUserDriveItemAsync(string name, Stream stream, string contentType)
        {
            // This method only supports files up to 4MB in size.
            return PutAsync<DriveItemModel>($"me/drive/special/approot:/{name}:/content",
                stream, contentType);
        }

        public Task<GroupModel[]> GetGroupsAsync()
        {
            // Expanding the total amount of groups to the maximum (999).
            return GetManyAsync<GroupModel>("groups?$top=999");
        }

        public Task<UserModel[]> GetGroupUsersAsync(GroupModel group)
        {
            return GetManyAsync<UserModel>($"groups/{group.Id}/members");
        }

        public Task<DriveItemModel[]> GetGroupDriveItemsAsync(GroupModel group)
        {
            return GetManyAsync<DriveItemModel>($"groups/{group.Id}/drive/root/children?select=id,name,webUrl");
        }

        public Task<ConversationModel[]> GetGroupConversationsAsync(GroupModel group)
        {
            return GetManyAsync<ConversationModel>($"groups/{group.Id}/conversations");
        }

        public Task<PlanModel[]> GetGroupPlansAsync(GroupModel group)
        {
            return GetManyAsync<PlanModel>($"groups/{group.Id}/plans");
        }

        public Task<GroupModel> AddGroupAsync(GroupModel group)
        {
            return PostAsync("groups/", group);
        }

        public Task<DriveItemModel> AddGroupDriveItemAsync(GroupModel group, string name, Stream stream,
            string contentType)
        {
            // This method only supports files up to 4MB in size.
            return PutAsync<DriveItemModel>($"groups/{group.Id}/drive/root:/{name}:/content",
                stream, contentType);
        }

        public Task AddGroupUserAsync(GroupModel group, UserModel user)
        {
            return PostAsync($"groups/{group.Id}/members/$ref", new IdModel
            {
                Id = _httpService.Resource.AbsoluteUri + "directoryObjects/" + user.Id
            });
        }

        public Task<NewConversationModel> AddGroupConversation(GroupModel group, NewConversationModel conversation)
        {
            return PostAsync($"groups/{group.Id}/threads", conversation);
        }

        public Task<PlanModel> AddGroupPlanAsync(GroupModel group, PlanModel plan)
        {
            return PostAsync("plans", plan);
        }

        public async Task<TableModel<T>> GetGroupTableAsync<T>(GroupModel group, DriveItemModel driveItem, string tableName) where T : TableRowModel, new()
        {
            return new TableModel<T>
            {
                Columns = await GetGroupTableColumnsAsync(group, driveItem, "PropertyTable")
            };
        }

        public Task<TableColumnModel[]> GetGroupTableColumnsAsync(GroupModel group, DriveItemModel driveItem, string tableName)
        {
            return GetManyAsync<TableColumnModel>($"groups/{group.Id}/drive/items/{driveItem.Id}/workbook/tables/{tableName}/columns");
        }

        public async Task<TableRowModel> AddGroupTableRowAsync(GroupModel group, DriveItemModel driveItem, string tableName, TableRowModel tableRow)
        {
            return (await PostAsync($"groups/{group.Id}/drive/items/{driveItem.Id}/workbook/tables/{tableName}/rows",
                new TableRowsModel
                {
                    Values = new[] { tableRow }
                })).Values.FirstOrDefault();
        }

        public Task<TableRowsModel> UpdateGroupTableRowsAsync(GroupModel group, DriveItemModel driveItem, string sheetName, string address,
            TableRowModel[] tableRows)
        {
            return PatchAsync($"groups/{group.Id}/drive/items/{driveItem.Id}/workbook/worksheets/{sheetName}/range(address='{sheetName}!{address}')",
                new TableRowsModel
                {
                    Values = tableRows
                });
        }

        public async Task WaitForGroupDriveAsync(GroupModel group)
        {
            while (true)
            {
                try
                {
                    // Try to get the drive. If it fails, the drive is 
                    // most likely still being configured.
                    await GetOneAsync<object>($"groups/{group.Id}/drive");
                    return;
                }
                catch
                {
                    await Task.Delay(2500);
                }
            }
        }

        public Task<BucketModel[]> GetPlanBucketsAsync(PlanModel plan)
        {
            return GetManyAsync<BucketModel>($"plans/{plan.Id}/buckets");
        }

        public Task<TaskModel[]> GetBucketTasksAsync(BucketModel bucket)
        {
            return GetManyAsync<TaskModel>($"buckets/{bucket.Id}/tasks");
        }

        public Task<BucketModel> AddBucketAsync(BucketModel bucket)
        {
            return PostAsync("/buckets", bucket);
        }

        public Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            return PostAsync("/tasks", task);
        }

        public async Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            // Set ETag. 
            var headers = _httpService.GetRequestHeaders();
            headers.IfMatch.Clear();
            headers.IfMatch.Add(new EntityTagHeaderValue(task.ETag.Substring(2,
                task.ETag.Length - 2), true));

            // Get result.
            var result = await PatchAsync($"/tasks/{task.Id}", task);

            // Clear ETag and return the result.
            headers.IfMatch.Clear();
            return result;
        }
    }
}