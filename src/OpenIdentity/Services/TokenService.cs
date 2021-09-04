using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public class TokenService : ITokenService
    {
        public Task<Token> CreateAccessTokenAsync(TokenSource token)
        {
            throw new NotImplementedException();
        }

        public Task<Token> CreateIdentityTokenAsync(TokenSource token)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateRefreshTokenAsync(TokenSource token)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateSecurityTokenAsync(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
