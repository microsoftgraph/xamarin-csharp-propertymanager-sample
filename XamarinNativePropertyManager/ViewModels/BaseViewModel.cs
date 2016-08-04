/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace XamarinNativePropertyManager.ViewModels
{
	public abstract class BaseV : MvxViewModel
    {
        protected bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public ICommand GoBackCommand => new MvxCommand(() => Close(this));

        public virtual void OnResume()
        {
            RaiseAllPropertiesChanged();
        }
    }
}
