using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenIdentity.Models;
using OpenIdentity.Services;

namespace OpenIdentity.Endpoints.Results
{
    public class TokenEndpointErrorResult : EndpointHandleResult
    {

        public IJsonSerializer JsonSerializer { get; }
        public ValidationResult ValidationResult { get; }

        public TokenEndpointErrorResult(IJsonSerializer jsonSerializer, ValidationResult clientValidationResult)
        {
            JsonSerializer = jsonSerializer;
            ValidationResult = clientValidationResult;
        }

        public override async Task ExecuteAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serializer(new ErrorResponse() {
                error = ValidationResult.Error,
                error_description = ValidationResult.ErrorDescription,
            });

            await context.Response.WriteAsync(json);
        }

        internal class ErrorResponse
        {
            public string error { get; set; }
            public string error_description { get; set; }
        }
    }
}
