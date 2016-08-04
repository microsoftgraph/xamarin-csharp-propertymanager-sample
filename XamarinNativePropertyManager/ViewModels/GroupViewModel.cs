/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using XamarinNativePropertyManager.Extensions;
using XamarinNativePropertyManager.Models;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.ViewModels
{
    public delegate void ConversationsChangedEventHandler(GroupViewModel sender);

    public delegate void FilesChangedEventHandler(GroupViewModel sender);

    public delegate void TasksChangedEventHandler(GroupViewModel sender);

    public class GroupViewModel : BaseV
    {
        private readonly IGraphService _graphService;
        private readonly IConfigService _configService;
        private readonly ILauncherService _launcherService;
        private readonly IFilePickerService _filePickerService;

        private PlanModel _groupPlan;
        private BucketModel _taskBucket;

        private string _conversationText;

        public string ConversationText
        {
            get { return _conversationText; }
            set
            {
                _conversationText = value;
                RaisePropertyChanged(() => ConversationText);
            }
        }

        private string _taskText;

        public string TaskText
        {
            get { return _taskText; }
            set
            {
                _taskText = value;
                RaisePropertyChanged(() => TaskText);
            }
        }

        public PropertyTableRowModel Details { get; set; }

        public GroupModel Group { get; set; }

        public ObservableCollection<FileModel> Files { get; set; }

        public ObservableCollection<ConversationModel> Conversations { get; set; }

        public ObservableCollection<TaskModel> Tasks { get; set; }

        public ICommand AddConversationCommand => new MvxCommand(AddConversationAsync);

        public ICommand EditDetailsCommand => new MvxCommand(EditDetails);

        public ICommand AddFileCommand => new MvxCommand(AddFileAsync);

        public ICommand AddTaskCommand => new MvxCommand(AddTaskAsync);

        public ICommand TaskClickCommand => new MvxCommand<TaskModel>(task => CompleteTaskAsync(task));

        public ICommand FileClickCommand => new MvxCommand<FileModel>(file => LaunchDriveItemAsync(file.DriveItem));

        public event ConversationsChangedEventHandler ConversationsChanged;

        public event FilesChangedEventHandler FilesChanged;

        public event TasksChangedEventHandler TasksChanged;

        public GroupViewModel(IGraphService graphService, IConfigService configService,
            ILauncherService launcherService, IFilePickerService filePickerService)
        {
            _graphService = graphService;
            _configService = configService;
            _launcherService = launcherService;
            _filePickerService = filePickerService;
            Files = new ObservableCollection<FileModel>();
            Conversations = new ObservableCollection<ConversationModel>();
            Tasks = new ObservableCollection<TaskModel>();
        }

        public void Init(string groupData)
        {
            // Deserialize the group.
            var group = JsonConvert.DeserializeObject<GroupModel>(groupData);
            Group = group;
        }

        public override async void Start()
        {
            IsLoading = true;

            // Get datails.
            Details = _configService.DataFile.PropertyTable
                .Rows.FirstOrDefault(r => r.Id == Group.Mail);

            // Update the rest of the data.
            try
            {
                await Task.WhenAll(
                    UpdateDriveItemsAsync(),
                    UpdateConversationsAsync(),
                    UpdateTasksAsync());
            }
            catch
            {
                // Ignored.
            }

            IsLoading = false;
            base.Start();
        }

        private async Task UpdateDriveItemsAsync()
        {
            var driveItems = await _graphService.GetGroupDriveItemsAsync(Group);
            foreach (var driveItem in driveItems)
            {
                if (Constants.MediaFileExtensions.Any(e => driveItem.Name.ToLower().Contains(e)))
                {
                    Files.Add(new FileModel(driveItem, FileType.Media));
                }
                else if (Constants.DocumentFileExtensions.Any(e => driveItem.Name.ToLower().Contains(e)))
                {
                    Files.Add(new FileModel(driveItem, FileType.Document));
                }
            }
            OnFilesChanged();
        }

        private async Task UpdateConversationsAsync()
        {
            var conversations = await _graphService.GetGroupConversationsAsync(Group);
            foreach (var conversation in conversations.Reverse())
            {
                conversation.IsOwnedByUser = conversation.UniqueSenders
                    .Any(us => us.Contains(_configService.User.DisplayName));
                Conversations.Add(conversation);
            }
            OnConversationsChanged();
        }

        public async Task UpdateTasksAsync()
        {
            // Get a group plan.
            var plans = await _graphService.GetGroupPlansAsync(Group);
            var plan = plans.FirstOrDefault();

            // If a group plan doesn't exist, create it.
            if (plan == null)
            {
                plan = await _graphService.AddGroupPlanAsync(Group,
                    new PlanModel
                    {
                        Title = Group.DisplayName,
                        Owner = Group.Id
                    });
            }

            // Get the task bucket.
            var buckets = await _graphService.GetPlanBucketsAsync(plan);
            var taskBucket = buckets.FirstOrDefault(b => b.Name.Equals(Constants.TaskBucketName));

            // If the task bucket doesn't exist, create it.
            if (taskBucket == null)
            {
                taskBucket = await _graphService.AddBucketAsync(new BucketModel
                {
                    Name = Constants.TaskBucketName,
                    PlanId = plan.Id
                });
            }

            // Get the tasks and add the ones that aren't completed.
            var tasks = await _graphService.GetBucketTasksAsync(taskBucket);
            Tasks.AddRange(tasks.Where(t => t.PercentComplete < 100));
            OnTasksChanged();

            // Store values.
            _groupPlan = plan;
            _taskBucket = taskBucket;
        }

        private void EditDetails()
        {
            // Navigate to the details view.
            ShowViewModel<DetailsViewModel>(new { id = Group.Mail });
        }

        private async void AddConversationAsync()
        {
            IsLoading = true;

            // Reset the text box.
            var text = ConversationText;
            ConversationText = "";

            // Create a local message and add it.
            var newConversation = new ConversationModel
            {
                Preview = text,
                UniqueSenders = new List<string> { _configService.User.DisplayName },
                IsOwnedByUser = true
            };
            Conversations.Add(newConversation);
            OnConversationsChanged();

            // Create the request object.
            var newThread = new NewConversationModel
            {
                Topic = "Property Manager",
                Posts = new List<NewPostModel>
                {
                    new NewPostModel
                    {
                        Body = new BodyModel(text, "html"),
                        NewParticipants = new List<ParticipantModel>
                        {
                            new ParticipantModel(_configService.User.DisplayName,
                                _configService.User.Mail)
                        }
                    }
                }
            };

            // Add the message.
            await _graphService.AddGroupConversation(Group, newThread);
            IsLoading = false;
        }

        private async void AddTaskAsync()
        {
            IsLoading = true;

            // Reset the text box.
            var text = TaskText;
            TaskText = "";

            // Create the request object.
            var task = new TaskModel
            {
                AssignedTo = _configService.User.Id,
                PlanId = _groupPlan.Id,
                BucketId = _taskBucket.Id,
                Title = text
            };

            // Add the task.
            task = await _graphService.AddTaskAsync(task);
            Tasks.Add(task);
            OnTasksChanged();
            IsLoading = false;
        }

        private async void AddFileAsync()
        {
            // Let the current user pick a file.
            using (var file = await _filePickerService.GetFileAsync())
            {
                if (file == null)
                {
                    return;
                }

                IsLoading = true;

                // Upload file to group.
                var driveItem = await _graphService.AddGroupDriveItemAsync(Group, file.Name,
                    file.Stream, Constants.StreamContentType);
                if (driveItem != null)
                {
                    // Remove a potential duplicate.
                    var existingDriveItem = Files
                        .FirstOrDefault(f => f.DriveItem.Name.Equals(driveItem.Name));
                    if (existingDriveItem != null)
                    {
                        Files.Remove(existingDriveItem);
                    }

                    Files.Add(new FileModel(driveItem,
                        Constants.MediaFileExtensions.Any(e => driveItem.Name.ToLower().Contains(e))
                            ? FileType.Media
                            : FileType.Document));
                    OnFilesChanged();
                }

                IsLoading = false;
            }
        }

        private void LaunchDriveItemAsync(DriveItemModel driveItem)
        {
            _launcherService.LaunchWebUri(new Uri(driveItem.WebUrl));
        }

        private async void CompleteTaskAsync(TaskModel task)
        {
            IsLoading = true;

            // Remove the task.
            Tasks.Remove(task);
            OnConversationsChanged();

            // Update the task. We can use an empty task as the id
            // used is grabbed from the request URL.
            task.PercentComplete = 100;
            await _graphService.UpdateTaskAsync(new TaskModel
            {
                Id = task.Id,
                ETag = task.ETag,
                PercentComplete = 100
            });

            IsLoading = false;
        }

        protected virtual void OnConversationsChanged()
        {
            ConversationsChanged?.Invoke(this);
        }

        protected virtual void OnFilesChanged()
        {
            FilesChanged?.Invoke(this);
        }

        protected virtual void OnTasksChanged()
        {
            TasksChanged?.Invoke(this);
        }
    }
}