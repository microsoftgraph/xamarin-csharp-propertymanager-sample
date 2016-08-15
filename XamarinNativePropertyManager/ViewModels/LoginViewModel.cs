/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json.Linq;
using XamarinNativePropertyManager.Models;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.ViewModels
{
    public class LoginViewModel : BaseV
    {
        private readonly IGraphService _graphService;
        private readonly IConfigService _configService;

        public ICommand LoginCommand => new MvxCommand(LoginAsync);

        public LoginViewModel(IGraphService graphService, IConfigService configService)
        {
            _graphService = graphService;
            _configService = configService;
        }

        private async void LoginAsync()
        {
            IsLoading = true;

            try
            {

                // Make sure that the Graph service is configured.
                await _graphService.EnsureTokenIsPresentAsync();
            }
            catch
            {
                IsLoading = false;
                return;
            }

            UserModel user = null;
            GroupModel[] userGroups = null;
            GroupModel[] allGroups = null;

            // Get the current user, its groups and all of the groups.
            await Task.WhenAll(
                Task.Run(async () =>
                {
                    user = await _graphService.GetUserAsync();
                }),
                Task.Run(async () =>
                {
                    userGroups = await _graphService.GetUserGroupsAsync();
                }),
                Task.Run(async () =>
                {
                    allGroups = await _graphService.GetGroupsAsync();
                }));

            // Get the group belonging to this app.
            var appGroup = allGroups.FirstOrDefault(g => g.Mail != null && g.Mail.StartsWith(
                Constants.AppGroupMail));

            // If the app group doesn't exist, create it.
            if (appGroup == null)
            {
                // Create a unique mail nickname.
                var mailNickname = Constants.AppGroupMail +
                                   new string(DateTime.UtcNow.Ticks
                                       .ToString()
                                       .ToCharArray()
                                       .Take(10)
                                       .ToArray());
                appGroup = await _graphService.AddGroupAsync(GroupModel.CreateUnified(
                    Constants.AppGroupDisplayName,
                    Constants.AppGroupDescription,
                    mailNickname));

                // Add the current user as a member of the app group.
                await _graphService.AddGroupUserAsync(appGroup, user);
            }

            // Add the current user as a member of the app group.
            var appGroupUsers = await _graphService.GetGroupUsersAsync(appGroup);
            if (appGroupUsers.All(u => u.UserPrincipalName != user.UserPrincipalName))
            {
                await _graphService.AddGroupUserAsync(appGroup, user);
            }

            // We need the file storage to be ready in order to place the data file. 
            // Wait for it to be configured.
            await _graphService.WaitForGroupDriveAsync(appGroup);

            // Get the app group files and the property data file.
            var appGroupDriveItems = await _graphService.GetGroupDriveItemsAsync(appGroup);
            var dataDriveItem = appGroupDriveItems.FirstOrDefault(i => i.Name.Equals(
                Constants.DataFileName));

            // If the data file doesn't exist, create it.
            if (dataDriveItem == null)
            {
                // Get the data file template from the resources.
                var assembly = typeof (App).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream(Constants.DataFileResourceName))
                {
                    dataDriveItem = await _graphService.AddGroupDriveItemAsync(appGroup,
                        Constants.DataFileName, stream, Constants.ExcelContentType);
                }

                if (dataDriveItem == null)
                {
                    throw new Exception("Could not create the property data file in the group.");
                }
            }

            // Get the property table.
            var propertyTable = await _graphService.GetGroupTableAsync<PropertyTableRowModel>(
                appGroup, dataDriveItem, Constants.DataFilePropertyTable);

            // Create the data file represenation.
            var dataFile = new DataFileModel
            {
                DriveItem = dataDriveItem,
                PropertyTable = propertyTable
            };

            // Get groups that the user is a member of and represents 
            // a property.
            var propertyGroups = userGroups
                .Where(g => propertyTable["Id"]
                    .Values.Any(v => v.Any() &&
                                     v[0].Type == JTokenType.String &&
                                     v[0].Value<string>().Equals(g.Mail,
                                         StringComparison.OrdinalIgnoreCase)))
                .ToArray();

            // Set (singleton) config.
            _configService.User = user;
            _configService.AppGroup = appGroup;
            _configService.Groups = new List<GroupModel>(propertyGroups);
            _configService.DataFile = dataFile;

            // Navigate to the groups view.
            ShowViewModel<GroupsViewModel>();

            // Update only the underlying field for a better UI experience.
            _isLoading = false;
        }
    }
}
