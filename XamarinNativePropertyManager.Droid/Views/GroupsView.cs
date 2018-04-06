/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Microsoft.Identity.Client;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.Droid.Views
{
    [Activity(Label = "GroupsView", Theme = "@style/Theme.Light",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class GroupsView : MvxAppCompatActivity<GroupsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnViewModelSet()
        {
            Title = "Properties";
            SetContentView(Resource.Layout.GroupsActivity);

            base.OnViewModelSet();
        }

        protected override void OnResume()
        {
            ViewModel.OnResume();
            base.OnResume();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.GroupsMenu, menu);

            // Find the search view.
            var searchItem = menu.FindItem(Resource.Id.action_groups_search);
            var searchView = (SearchView)MenuItemCompat.GetActionView(searchItem);

            // Create the binding set and set bind the search
            // view query.
            var set = this.CreateBindingSet<GroupsView, GroupsViewModel>();
            set.Bind(searchView).For(s => s.Query).To(vm => vm.Query);
            set.Apply();

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_groups_add)
            {
                ViewModel.AddPropertyCommand.Execute(null);
            }
            return base.OnOptionsItemSelected(item);
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(
                requestCode, resultCode, data);
        }
    }
}