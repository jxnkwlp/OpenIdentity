using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public interface ITokenRequestService
    {
        Task<TokenRequestResult> RequestAsync(HttpContext httpContext, ClientValidationResult clientValidationResult);
    }
}
