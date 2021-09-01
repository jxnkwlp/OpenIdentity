using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OpenIdentity.Endpoints.Results
{
    public interface IEndpointHandleResult
    {
        Task ExecuteAsync(HttpContext context);
    }
}
