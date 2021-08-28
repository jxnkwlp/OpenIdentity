using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace OpenIdentity.Endpoints
{
    public class DiscoveryEndpoint : IRouteEndpointHandler
    {
        public Task<RouteEndpointHandleResponse> HandleAsync(RouteEndpointHandleRequest request)
        { 
            throw new NotImplementedException();
        }
    }

}
