using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using UIKit;
using XamarinNativePropertyManager.Services;

namespace XamarinNativePropertyManager.iOS.Services
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
			var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			var platformParameters = new PlatformParameters(viewController);
			try
			{
				// Authenticate the user.
				var authenticationResult = await authenticationContext.AcquireTokenAsync(
					Constants.GraphResource, Constants.ClientId, Constants.RedirectUri, platformParameters);
				return authenticationResult;
			}
			catch (AdalException ex)
			{
				if (ex.ErrorCode == AdalError.AuthenticationCanceled)
				{
					return null;
				}
				throw;
			}
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

