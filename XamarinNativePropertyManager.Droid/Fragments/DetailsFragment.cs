/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;

namespace XamarinNativePropertyManager.Droid.Fragments
{
    public class DetailsFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, 
            Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.DetailsFragment, null);
        }
    }
}