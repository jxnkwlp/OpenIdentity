//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;
//using OpenIdentity.Abstractions.Stores;

//namespace OpenIdentity.Endpoints
//{
//    public class AuthorizationEndpoint : IEndpointHandler
//    {
//        private ILogger<AuthorizationEndpoint> _logger;
//        private readonly IClientStore _clientStore;

//        public AuthorizationEndpoint(ILogger<AuthorizationEndpoint> logger, IClientStore clientStore)
//        {
//            _logger = logger;
//            _clientStore = clientStore;
//        }

//        public Task HandleAsync(EndpointHandleContext context)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
