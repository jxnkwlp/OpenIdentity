using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Extensions;
using OpenIdentity.Models;

namespace OpenIdentity.Validation
{
    public class ClientValidator : IClientValidator
    {
        private readonly ILogger<ClientValidator> _logger;
        private readonly IClientStore _clientStore;

        public async Task<ClientValidationResult> ValidateAsync(HttpContext httpContext)
        {
            var result = new ClientValidationResult();

            // get params
            var clientId = httpContext.GetClientId();
            var clientSecret = httpContext.GetClientSecret();

            if (clientId.IsNullOrEmpty())
            {
                result.Error = "invalid request";
                result.ErrorDescription = "client_id not found.";

                _logger.LogDebug("Client id not found from request.");

                return result;
            }

            // find client 
            var client = await _clientStore.FindByIdAsync(clientId);

            if (client == null)
            {
                result.Error = "invalid request";
                result.ErrorDescription = "unknow client.";

                _logger.LogDebug($"Client id '{clientId}' not found.");

                return result;
            }

            // secret
            if (client.RequireSecret)
            {
                if (clientSecret.IsNullOrEmpty())
                {
                    result.Error = "invalid request";
                    result.ErrorDescription = "client_secret not found.";

                    _logger.LogDebug("Client secret not found from request.");

                    return result;
                }

                // TODO
            }

            return result;
        }
    }
}
