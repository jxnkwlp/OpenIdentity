using System;

namespace OpenIdentity.Models
{
    public class TokenResponse
    {
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset ExpiresTime { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
}
