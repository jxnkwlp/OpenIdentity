using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Endpoints;
using OpenIdentity.Services;
using OpenIdentity.Stores;
using OpenIdentity.Validation;

namespace OpenIdentity
{
    public static class ServiceCollectionExtensions
    {
        public static OpenIdentityOptionsBuilder AddOpenIdentity(this IServiceCollection services, Action<OpenIdentityOptions> optionBuilder)
        {
            var builder = new OpenIdentityOptionsBuilder(services);

            // options
            var options = new OpenIdentityOptions();
            optionBuilder?.Invoke(options);

            services.TryAddSingleton(options);

            // core
            services.AddOpenIdentityCore();

            return builder;
        }

        private static void AddOpenIdentityCore(this IServiceCollection services)
        {
            //services.AddTransient<IClientStore, DefaultMemoryClientStore>();
            //services.AddTransient<IRouteEndpointHandler, AuthorizationEndpoint>();
            //services.AddTransient<IRouteEndpointHandler, TokenEndpoint>();
            //services.AddSingleton<TokenEndpointManager>();
            //services.AddTransient<IUserService, UserService>();

            // endpoints
            services.AddTransient<TokenEndpoint>();


            // stores 
            services.AddTransient<IClientStore, DefaultMemoryClientStore>();


            // services
            services.AddTransient<IJsonSerializer, DefaultJsonSerializer>();
            services.AddTransient<ITokenRequestService, TokenRequestService>();
            services.AddTransient<ITokenService, TokenService>();


            // validations
            services.AddTransient<IClientValidator, ClientValidator>();

        }
    }
}
