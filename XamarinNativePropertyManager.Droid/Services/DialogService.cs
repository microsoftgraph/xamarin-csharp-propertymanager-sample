/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.Droid.Services
{
    public class DialogService : IDialogService
    {
        public IDialogHandle ShowProgress(string title, string message)
        {
            return new ProgressDialogHandle(title, message);
        }
    }
}