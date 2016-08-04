/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace XamarinNativePropertyManager.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AcquireTokenAsync();

        Task<AuthenticationResult> AcquireTokenSilentAsync();
    }
}
