/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using XamarinNativePropertyManager.ViewModels;
using Java.Lang;
using MvvmCross.Platform.IoC;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    [MvxUnconventional]
    [Register("xamarinnativepropertymanager.droid.fragments.FilesFragment")]
    public class FilesFragment : MvxFragment<GroupViewModel>
    {
        private MvxListView _filesListView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.FilesFragment, null);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            ViewModel.FilesChanged += OnFilesChanged;

            // Get the list view.
            _filesListView = view.FindViewById<MvxListView>(Resource.Id.files_list_view);
        }

        private void OnFilesChanged(GroupViewModel sender)
        {
            _filesListView.Post(new Runnable(() =>
            {
                _filesListView.SetSelection(sender.Files.Count - 1);
            }));
        }
    }
}