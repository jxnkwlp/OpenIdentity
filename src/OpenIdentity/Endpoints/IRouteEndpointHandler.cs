using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OpenIdentity.Endpoints
{
    public interface IRouteEndpointHandler
    {
        Task<RouteEndpointHandleResponse> HandleAsync(RouteEndpointHandleRequest request);
    }

    public class RouteEndpointHandleRequest
    {
        public RouteEndpointHandleRequest(string method, IQueryCollection query, IFormCollection form)
        {
            Method = method;
            Query = query;
            Form = form;
        }

        public string Method { get; }
        public IQueryCollection Query { get; }
        public IFormCollection Form { get; }
    }

    public class RouteEndpointHandleResponse
    {
        public string RedirectUrl { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Error { get; set; }
        public string Json { get; set; }
    }
}
