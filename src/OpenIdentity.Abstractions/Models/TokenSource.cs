using System.Security.Claims;
using OpenIdentity.Abstractions;

namespace OpenIdentity.Models
{
    public class TokenSource
    {
        public ClaimsPrincipal Identity { get; set; }

        public Client Client { get; set; }

        public string[] Scopes { get; set; }

        public string AccessTokenToHash { get; set; }

        public string AuthorizationCodeToHash { get; set; }

        public string Nonce { get; set; }
    }
}
