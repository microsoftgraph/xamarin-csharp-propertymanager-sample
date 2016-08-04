/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.IO;
using System.Threading.Tasks;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public interface IGraphService
    {
        Task EnsureTokenIsPresentAsync();

        Task<UserModel> GetUserAsync();

        Task<GroupModel[]> GetUserGroupsAsync();

        Task<DriveItemModel[]> GetUserDriveItemAsync();

        Task<DriveItemModel> AddUserDriveItemAsync(string name, Stream stream, string contentType);

        Task<GroupModel[]> GetGroupsAsync();

        Task<UserModel[]> GetGroupUsersAsync(GroupModel group);

        Task<DriveItemModel[]> GetGroupDriveItemsAsync(GroupModel group);

        Task<ConversationModel[]> GetGroupConversationsAsync(GroupModel group);

        Task<PlanModel[]> GetGroupPlansAsync(GroupModel group);

        Task<GroupModel> AddGroupAsync(GroupModel group);

        Task<DriveItemModel> AddGroupDriveItemAsync(GroupModel group, string name, Stream stream, string contentType);

        Task AddGroupUserAsync(GroupModel group, UserModel user);

        Task<NewConversationModel> AddGroupConversation(GroupModel group, NewConversationModel conversation);

        Task<PlanModel> AddGroupPlanAsync(GroupModel group, PlanModel plan);

        Task<TableModel<T>> GetGroupTableAsync<T>(GroupModel group, DriveItemModel driveItem, string tableName) where T : TableRowModel, new();

        Task<TableColumnModel[]> GetGroupTableColumnsAsync(GroupModel group, DriveItemModel driveItem, string tableName);

        Task<TableRowModel> AddGroupTableRowAsync(GroupModel group, DriveItemModel driveItem, string tableName, TableRowModel tableRow);

        Task<TableRowsModel> UpdateGroupTableRowsAsync(GroupModel group, DriveItemModel driveItem, string sheetName, string address, TableRowModel[] tableRows);

        Task WaitForGroupDriveAsync(GroupModel group);

        Task<BucketModel[]> GetPlanBucketsAsync(PlanModel plan);

        Task<TaskModel[]> GetBucketTasksAsync(BucketModel bucket);

        Task<BucketModel> AddBucketAsync(BucketModel bucket);

        Task<TaskModel> AddTaskAsync(TaskModel task);

        Task<TaskModel> UpdateTaskAsync(TaskModel task);
    }
}