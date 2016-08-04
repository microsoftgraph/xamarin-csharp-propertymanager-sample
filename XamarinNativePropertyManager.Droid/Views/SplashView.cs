/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace XamarinNativePropertyManager.Droid.Views
{
    [Activity(
        Label = "Property Manager"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashView : MvxSplashScreenActivity
    {
        public SplashView()
            : base(Resource.Layout.SplashActivity)
        {
            
        }
    }
}
