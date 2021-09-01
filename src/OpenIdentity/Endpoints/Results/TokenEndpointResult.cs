using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenIdentity.Models;
using OpenIdentity.Services;

namespace OpenIdentity.Endpoints.Results
{
    public class TokenEndpointResult : EndpointHandleResult
    {
        public TokenEndpointResult(IJsonSerializer jsonSerializer, ClientValidationResult clientValidationResult, TokenRequestResult tokenRequestResult)
        {
            JsonSerializer = jsonSerializer;
            ClientValidationResult = clientValidationResult;
            TokenRequestResult = tokenRequestResult;
        }

        public IJsonSerializer JsonSerializer { get; }
        public ClientValidationResult ClientValidationResult { get; }
        public TokenRequestResult TokenRequestResult { get; }


        public override async Task ExecuteAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            // TODO 
            var json = JsonSerializer.Serializer(new TokenResponse() {
            });

            await context.Response.WriteAsync(json);
        }

        internal class TokenResponse
        {
            public string access_token { get; set; }
            public string refresh_token { get; set; }
            public string id_token { get; set; }
            public string expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
        }
    }
}
