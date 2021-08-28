using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenIdentity.Abstractions.Stores;

namespace OpenIdentity.Endpoints
{
    public class AuthorizationEndpoint : IRouteEndpointHandler
    {
        private ILogger<AuthorizationEndpoint> _logger;
        private readonly IClientStore _clientStore;

        public AuthorizationEndpoint(ILogger<AuthorizationEndpoint> logger, IClientStore clientStore)
        {
            _logger = logger;
            _clientStore = clientStore;
        }

        public Task<RouteEndpointHandleResponse> HandleAsync(RouteEndpointHandleRequest request)
        {
            // if()
            // client 

            throw new NotImplementedException();
        }
    }
}
