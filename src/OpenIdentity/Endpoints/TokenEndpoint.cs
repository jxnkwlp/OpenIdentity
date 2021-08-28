using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenIdentity.Abstractions.Stores;

namespace OpenIdentity.Endpoints
{
    public class TokenEndpoint : IRouteEndpointHandler
    {
        private readonly ILogger<AuthorizationEndpoint> _logger;
        private readonly IClientStore _clientStore;

        public TokenEndpoint(ILogger<AuthorizationEndpoint> logger, IClientStore clientStore)
        {
            _logger = logger;
            _clientStore = clientStore;
        }

        public Task<RouteEndpointHandleResponse> HandleAsync(RouteEndpointHandleRequest request)
        {
            // validation

            if (request.Method != "POST")
            {
                return new RouteEndpointHandleResponse
                {
                    StatusCode = 400,
                    Json = "{}", // { "error", "invalid_request", "error_message" :"client id not found. ... " }
                };
            }

            request.Query.TryGetValue("grant_type", out var grantType);
            request.Query.TryGetValue("username", out var username);
            request.Query.TryGetValue("password", out var password);
            request.Query.TryGetValue("client_id", out var clientId);


            var tokenRequest = new TokenRequest();

            // check flow
            if (tokenRequest.GrandType == GrandTypes.Password)
            {
            }
            else if (tokenRequest.GrandType == GrandTypes.Password)
            {
            }

            // response

        }
    }

    public class TokenRequest
    {
        public string GrandType { get; set; }
    }
}
