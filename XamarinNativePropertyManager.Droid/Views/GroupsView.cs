using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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

            // Configure the search view by feeding the query back
            // into the view model.
            var searchItem = menu.FindItem(Resource.Id.action_groups_search);
            var searchView = (SearchView)MenuItemCompat.GetActionView(searchItem);
            searchView.QueryTextChange += (sender, e) =>
            {
                ViewModel.Query = e.NewText;
            };
            searchView.QueryTextSubmit += (sender, e) =>
            {
                ViewModel.Query = e.Query;
                e.Handled = true;
            };
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
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(
                requestCode, resultCode, data);
        }
    }
}