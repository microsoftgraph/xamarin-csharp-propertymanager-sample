/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using MvvmCross.Droid.Support.V4;

namespace XamarinNativePropertyManager.Droid.Adapters
{
    public class FragmentInfo
    {
        public string Title { get; set; }

        public MvxFragment Fragment { get; set; }

        public FragmentInfo(string title, MvxFragment fragment)
        {
            Title = title;
            Fragment = fragment;
        }
    }
}