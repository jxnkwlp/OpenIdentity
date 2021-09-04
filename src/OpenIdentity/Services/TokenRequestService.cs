using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenIdentity.Extensions;
using OpenIdentity.Models;

namespace OpenIdentity.Services
{
    public class TokenRequestService : ITokenRequestService
    {
        private readonly ILogger<TokenRequestService> _logger;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenRequestService(ILogger<TokenRequestService> logger, IUserService userService, ITokenService tokenService)
        {
            _logger = logger;
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<TokenRequestResult> RequestAsync(HttpContext httpContext, ClientValidationResult clientValidationResult)
        {
            var grantType = httpContext.GetGrantType();

            if (grantType.IsNullOrEmpty())
            {
                return new TokenRequestResult()
                {
                    ErrorDescription = "grant_type not found.",
                };
            }

            var formValues = await httpContext.Request.ReadFormAsync();

            // client protocol type

            // grant type
            if (grantType == GrandTypes.AuthorizationCode)
            {
            }
            else if (grantType == GrandTypes.ClientCredentials)
            {
                return await ClientCredentialsRequestAsync();
            }
            else if (grantType == GrandTypes.Implicit)
            {
            }
            else if (grantType == GrandTypes.RefreshToken)
            {
            }
            else if (grantType == GrandTypes.Password)
            {
                return await PasswordRequestAsync(formValues, clientValidationResult);
            }
            else
            {
                // TODO
            }


            throw new NotImplementedException();
        }

        protected virtual Task<TokenRequestResult> ClientCredentialsRequestAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual async Task<TokenRequestResult> PasswordRequestAsync(IFormCollection forms, ClientValidationResult clientValidationResult)
        {
            var result = new TokenRequestResult();

            var client = clientValidationResult.Client;

            // grant type 
            if (!client.AllowedGrantTypes.Contains(GrandTypes.Password))
            {
                return new TokenRequestResult() { ErrorDescription = $"grant type not supported." };
            }

            // scopes

            // credentials
            var userName = forms.Get("username");
            var password = forms.Get("password");

            var validateResult = await _userService.ValidateAsync(new UserValidationRequest()
            {
                UserName = userName,
                Password = password,
                ClientId = client.Id,
            });

            if (!validateResult.Success)
            {
                return new TokenRequestResult()
                {
                    Error = validateResult.Error,
                    ErrorDescription = "invalid_username_or_password"
                };
            }
            else
            {
                // TODO
                // token generate
                var identityToken = await _tokenService.CreateIdentityTokenAsync(new TokenSource());
                var accessToken = await _tokenService.CreateAccessTokenAsync(new TokenSource());
                var refreshToken = await _tokenService.CreateRefreshTokenAsync(new TokenSource());

                // TODO 
                return new TokenRequestResult()
                {
                    Token = new TokenResponse()
                    {
                        ExpiresTime = DateTimeOffset.Now.AddMinutes(5),
                        AccessToken = await _tokenService.CreateSecurityTokenAsync(accessToken),
                        IdToken = await _tokenService.CreateSecurityTokenAsync(identityToken),
                        RefreshToken = refreshToken,
                    },
                };
            }
        }
    }
}
