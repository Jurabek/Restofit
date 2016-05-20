using System.Net.Http;
using Refit;

namespace Restofit.Core.Models
{
    internal abstract class Context
    {
        private static AuthenticationManager _authenticationManager;
        public static AuthenticationManager AuthenticationManager 
            => _authenticationManager ?? (_authenticationManager = new AuthenticationManager());
    }

    internal class AuthenticationManager
    {
        public HttpClient AuthenticatedClient { get; set; }

        private IRestaurantApi authenticatedApi;
        public IRestaurantApi AuthenticatedApi => 
            authenticatedApi ?? (authenticatedApi = RestService.For<IRestaurantApi>(AuthenticatedClient));
    }
}
