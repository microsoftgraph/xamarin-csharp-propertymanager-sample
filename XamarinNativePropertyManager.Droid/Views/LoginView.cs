/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Microsoft.Identity.Client;
using MvvmCross.Droid.Support.V7.AppCompat;
using XamarinNativePropertyManager.ViewModels;

namespace XamarinNativePropertyManager.Droid.Views
{
    [Activity(Label = "LoginView", Theme = "@style/Theme.Light.NoActionBar",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginView : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.LoginActivity);
            base.OnViewModelSet();
        }

        protected override void OnResume()
        {
            ViewModel.OnResume();
            base.OnResume();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(
                requestCode, resultCode, data);
        }
    }
}