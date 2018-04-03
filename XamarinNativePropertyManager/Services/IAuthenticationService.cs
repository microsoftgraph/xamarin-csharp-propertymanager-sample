/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace XamarinNativePropertyManager.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AcquireTokenAsync();

        Task<AuthenticationResult> AcquireTokenSilentAsync();
    }
}
