/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Linq;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using XamarinNativePropertyManager.Models;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly IGraphService _graphService;
        private readonly IConfigService _configService;
        private readonly IDialogService _dialogService;

        private bool _isValid;

        public bool IsValid
        {
            get { return !IsLoading && _isValid; }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        private string _streetName;

        public string StreetName
        {
            get { return _streetName; }
            set
            {
                _streetName = value;
                RaisePropertyChanged(() => StreetName);
            }
        }

        public PropertyTableRowModel Details { get; set; }

        public bool IsExisting { get; set; }

        public ICommand SaveDetailsCommand => new MvxCommand(SaveDetailsAsync);

        public DetailsViewModel(IGraphService graphService, IConfigService configService,
            IDialogService dialogService)
        {
            _graphService = graphService;
            _configService = configService;
            _dialogService = dialogService;
        }

        public void Init(string id)
        {
            // Get details.
            Details = _configService.DataFile.PropertyTable
                .Rows.FirstOrDefault(r => r.Id == id);
            IsExisting = Details != null;

            // Set title.
            Title = (!IsExisting ? "Add" : "Edit") + " a property";
            if (Details == null)
            {
                Details = new PropertyTableRowModel();
            }
            Validate();
        }

        private async void SaveDetailsAsync()
        {
            IsLoading = true;
            // Show a progress dialog.
            var progressDialog = _dialogService.ShowProgress("Please wait...", 
                "The details are being saved to your Office 365 tenant.");

            if (IsExisting)
            {
                // Calculate address (range).
                const int startRow = 2;
                var endRow = 2 + (_configService.DataFile.PropertyTable.Rows.Length - 1);
                var address = $"{Constants.DataFilePropertyTableColumnStart}{startRow}:" +
                              $"{Constants.DataFilePropertyTableColumnEnd}{endRow}";

                // Update the table row.
                await _graphService.UpdateGroupTableRowsAsync(_configService.AppGroup, 
                    _configService.DataFile.DriveItem, Constants.DataFileDataSheet, address, 
                    _configService.DataFile.PropertyTable.Rows .Cast<TableRowModel>().ToArray());
            }
            else
            {
                // Create property group.
                var mailNickname = new string(_streetName.ToCharArray()
                    .Where(char.IsLetterOrDigit)
                    .ToArray())
                    .ToLower();
                var propertyGroup = await _graphService.AddGroupAsync(GroupModel.CreateUnified(
                    StreetName, 
                    Details.Description, 
                    mailNickname));

                // Add the current user as a member of the app group.
                await _graphService.AddGroupUserAsync(propertyGroup, _configService.User);

                // We need the file storage to be ready in order to place any files.
                // Wait for it to be configured.
                await _graphService.WaitForGroupDriveAsync(propertyGroup);

                // Add details to data file.
                Details.Id = propertyGroup.Mail;
                await _graphService.AddGroupTableRowAsync(_configService.AppGroup, 
                    _configService.DataFile.DriveItem, Constants.DataFilePropertyTable, Details);

                // Add group and details to local config.
                _configService.Groups.Add(propertyGroup);
                _configService.DataFile.PropertyTable.AddRow(Details);
            }

            // Close the progress dialog.
            progressDialog.Close();
            IsLoading = false;
            GoBackCommand.Execute(null);
        }

        public void Validate()
        {
            // Validate street name if needed.
            var isStreetNameValid = IsExisting ||
                                    (!string.IsNullOrWhiteSpace(_streetName) && _streetName.Length > 4);
            IsValid = isStreetNameValid &&
                      !string.IsNullOrWhiteSpace(Details.Description) &&
                      !string.IsNullOrWhiteSpace(Details.Rooms) &&
                      !string.IsNullOrWhiteSpace(Details.LivingArea) &&
                      !string.IsNullOrWhiteSpace(Details.LotSize) &&
                      !string.IsNullOrWhiteSpace(Details.OperatingCosts);
        }
    }
}