/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using MvvmCross.Droid.Support.V7.AppCompat;
using XamarinNativePropertyManager.ViewModels;
using System.Collections.Generic;

namespace XamarinNativePropertyManager.Droid.Views
{
    [Activity(Label = "DetailsView", Theme = "@style/Theme.Light",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class DetailsView : MvxAppCompatActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnViewModelSet()
        {
            Title = ViewModel.Title;
            SetContentView(Resource.Layout.DetailsActivity);
            base.OnViewModelSet();

            // Get all of the EditTexts and trigger validation whenever
            // an input change occurs.
            var editTexts = new List<EditText>
            {
                (EditText)FindViewById(Resource.Id.street_name_edit_text),
                (EditText)FindViewById(Resource.Id.description_edit_text),
                (EditText)FindViewById(Resource.Id.rooms_edit_text),
                (EditText)FindViewById(Resource.Id.lot_size_edit_text),
                (EditText)FindViewById(Resource.Id.living_area_edit_text),
                (EditText)FindViewById(Resource.Id.operating_costs_edit_text),
            };

            // Hook up the event handler.
            foreach (var editText in editTexts)
            {
                editText.AfterTextChanged += (sender, e) => ViewModel.Validate();
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(
                requestCode, resultCode, data);
        }
    }
}