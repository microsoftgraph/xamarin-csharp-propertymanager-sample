/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Microsoft.Identity.Client;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.Droid.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private void SaveCurrentUUID(string uuid)
        {
            var preferences = Application.Context.GetSharedPreferences("PM",
                      FileCreationMode.Private);
            var editor = preferences.Edit();
            editor.PutString("UUID", uuid);
            editor.Commit();
        }

        private string GetCurrentUUID()
        {
            var preferences = Application.Context.GetSharedPreferences("PM",
                FileCreationMode.Private);
            return preferences.GetString("UUID", null);
        }

        public async Task<AuthenticationResult> AcquireTokenAsync()
        {
            // Get the top activity.
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            if (topActivity == null)
            {
                throw new Exception("Could not find the top Activity.");
            }

            // Create a public client app
            PublicClientApplication pca = new PublicClientApplication(Constants.ClientId, Constants.Authority);

            try
            {
                // Authenticate the user.
                var authenticationResult = await pca.AcquireTokenAsync(Constants.Scopes, new UIParent(topActivity));

                // Naively store the unique user id.
                SaveCurrentUUID(authenticationResult.UniqueId);
                return authenticationResult;
            }
            catch (MsalClientException ex)
            {
                if (ex.ErrorCode == MsalClientException.AuthenticationCanceledError)
                {
                    return null;
                }
                throw;
            }
        }

        public async Task<AuthenticationResult> AcquireTokenSilentAsync()
        {
            // Create a public client app
            PublicClientApplication pca = new PublicClientApplication(Constants.ClientId, Constants.Authority);

            // Try to get a unique user id.
            var uuid = GetCurrentUUID();

            // Authenticate the user.
            var authenticationResult = await pca.AcquireTokenSilentAsync(Constants.Scopes, pca.Users.FirstOrDefault());
            return authenticationResult;
        }
    }
}
