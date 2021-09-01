using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenIdentity.Endpoints;

namespace OpenIdentity.Managers
{
   public class TokenEndpointManager
    {
        public Task<bool> RequestMethodValidation(RouteEndpointHandleRequest request)
        {
            return Task.FromResult(request.Method == "POST");
        }

        public Task<bool> RequestParamsValidation(RouteEndpointHandleRequest request)
        {
            if (!request.Query.Keys.Contains("grant_type")
                || !request.Query.Keys.Contains("username")
                || !request.Query.Keys.Contains("password")
                || !request.Query.Keys.Contains("client_id"))
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

    }
}
