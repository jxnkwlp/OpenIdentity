using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OpenIdentity.Endpoints.Results
{
    public abstract class EndpointHandleResult : IEndpointHandleResult
    {
        public virtual Task ExecuteAsync(HttpContext context)
        {
            return Task.CompletedTask;
        }
    }
}
