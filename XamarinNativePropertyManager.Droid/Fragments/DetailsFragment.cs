/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using XamarinNativePropertyManager.ViewModels;
using MvvmCross.Platform.IoC;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    [MvxUnconventional]
    public class DetailsFragment : MvxFragment<GroupViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.DetailsFragment, null);
        }
    }
}