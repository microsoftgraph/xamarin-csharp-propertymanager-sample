using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.UWP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResult> AcquireTokenAsync()
        {
            // Clear the cache.
            TokenCache.DefaultShared.Clear();

            // Create the authentication context.
            var authenticationContext = new AuthenticationContext(Constants.Authority);

            // Create the platform parameters.
            var platformParameters = new PlatformParameters(PromptBehavior.Always,
                false);

            // Authenticate the user.
            var authenticationResult = await authenticationContext.AcquireTokenAsync(
                Constants.GraphResource, Constants.ClientId, Constants.RedirectUri, platformParameters); 
            return authenticationResult;
        }

        public async Task<AuthenticationResult> AcquireTokenSilentAsync()
        {
            // Create the authentication context.
            var authenticationContext = new AuthenticationContext(Constants.Authority);

            // Authenticate the user.
            var authenticationResult = await authenticationContext.AcquireTokenSilentAsync(
                Constants.GraphResource, Constants.ClientId);
            return authenticationResult;
        }
    }
}
