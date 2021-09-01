using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenIdentity.Abstractions.Stores;
using System.Linq;
using OpenIdentity.Managers;
using JWT.Algorithms;
using JWT;
using System.Collections.Generic;
using JWT.Serializers;
using OpenIdentity.Services;
using OpenIdentity.Models;

namespace OpenIdentity.Endpoints
{
    public class TokenEndpoint : IRouteEndpointHandler
    {
        private readonly ILogger<AuthorizationEndpoint> _logger;
        private readonly IClientStore _clientStore;
        private readonly TokenEndpointManager _tokenEndpointManager;
        private readonly IUserService _userService;

        public TokenEndpoint(ILogger<AuthorizationEndpoint> logger, IClientStore clientStore, TokenEndpointManager tokenEndpointManager, IUserService userService)
        {
            _logger = logger;
            _clientStore = clientStore;
            _tokenEndpointManager = tokenEndpointManager;
            _userService = userService;
        }

        public async Task<RouteEndpointHandleResponse> HandleAsync(RouteEndpointHandleRequest request)
        {
            // validation

            if (await _tokenEndpointManager.RequestMethodValidation(request)
                || await _tokenEndpointManager.RequestParamsValidation(request))
            {
                return new RouteEndpointHandleResponse {
                    StatusCode = 400,
                    Json = "{\"error\", \"invalid_request\"}"
                };
            }

            request.Query.TryGetValue("grant_type", out var grantType);
            request.Query.TryGetValue("username", out var username);
            request.Query.TryGetValue("password", out var password);
            request.Query.TryGetValue("client_id", out var clientId);

            var tokenRequest = new TokenRequest();

            // check flow
            if (grantType == GrandTypes.Password)
            {
                UserVerifyRequest userVerifyRequest = new UserVerifyRequest() { ClientId = clientId };

                if (!await _userService.VerifyAsync(username,password, userVerifyRequest))
                {
                    return new RouteEndpointHandleResponse {
                        StatusCode = 403,
                        Json = "{\"error\" : \"client not found\"}"
                    };
                }

                //TODO 生成token
            }else if (tokenRequest.GrandType == GrandTypes.AuthorizationCode)
            {
                
            }

            // response

            throw new NotImplementedException();
        }
    }

    public class TokenRequest
    {
        public string GrandType { get; set; }
    }
}
