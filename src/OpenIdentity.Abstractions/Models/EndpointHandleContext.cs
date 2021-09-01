using Microsoft.AspNetCore.Http;

namespace OpenIdentity.Endpoints
{
    public class EndpointHandleContext
    {
        public HttpContext HttpContext { get; }

        public EndpointHandleContext(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }

    }
}
