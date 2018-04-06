/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.UWP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResult> AcquireTokenAsync()
        {
            // Create a public client app
            PublicClientApplication pca = new PublicClientApplication(Constants.ClientId, Constants.Authority);

            // Authenticate the user.
            var authenticationResult = await pca.AcquireTokenAsync(Constants.Scopes);
            return authenticationResult;
        }

        public async Task<AuthenticationResult> AcquireTokenSilentAsync()
        {
            // Create a public client app
            PublicClientApplication pca = new PublicClientApplication(Constants.ClientId, Constants.Authority);

            // Authenticate the user.
            var authenticationResult = await pca.AcquireTokenSilentAsync(Constants.Scopes, pca.Users.FirstOrDefault());
            return authenticationResult;
        }
    }
}
