using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenIdentity.Endpoints.Results;
using OpenIdentity.Services;
using OpenIdentity.Validation;

namespace OpenIdentity.Endpoints
{
    public class TokenEndpoint : IEndpointHandler
    {
        private readonly ILogger<TokenEndpoint> _logger;
        private readonly IClientValidator _clientValidator;
        private readonly ITokenRequestService _tokenRequestService;
        private readonly IJsonSerializer _jsonSerializer;

        public TokenEndpoint(ILogger<TokenEndpoint> logger, IClientValidator clientValidator, ITokenRequestService tokenRequestService, IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _clientValidator = clientValidator;
            _tokenRequestService = tokenRequestService;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<IEndpointHandleResult> HandleAsync(EndpointHandleContext context)
        {
            _logger.LogDebug("Starting token request.");

            var clientValidationResult = await _clientValidator.ValidateAsync(context.HttpContext);

            if (!clientValidationResult.Success)
            {
                return new TokenEndpointErrorResult(_jsonSerializer, clientValidationResult);
            }

            var tokenResult = await _tokenRequestService.RequestAsync(context.HttpContext, clientValidationResult);

            if (!tokenResult.Success)
            {
                return new TokenEndpointErrorResult(_jsonSerializer, clientValidationResult);
            }

            return new TokenEndpointResult(_jsonSerializer, clientValidationResult, tokenResult);
        }
    }
}
