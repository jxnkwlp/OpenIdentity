using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Endpoints;
using OpenIdentity.Managers;
using OpenIdentity.Services;
using OpenIdentity.Stores;

namespace OpenIdentity
{
    public static class ServiceCollectionExtensions
    {
        public static OpenIdentityOptionsBuilder AddOpenIdentity(this IServiceCollection services, Action<OpenIdentityOptions> optionBuilder)
        {
            var builder = new OpenIdentityOptionsBuilder(services);

            var options = new OpenIdentityOptions();
            optionBuilder?.Invoke(options);

            services.TryAddSingleton(options);

            services.AddOpenIdentityCore();

            builder.AddDefaultClientStore();

            return builder;
        }

        private static void AddOpenIdentityCore(this IServiceCollection services)
        {
            services.AddTransient<IClientStore, DefaultMemoryClientStore>();
            services.AddTransient<IRouteEndpointHandler, AuthorizationEndpoint>();
            services.AddTransient<IRouteEndpointHandler, TokenEndpoint>();
            services.AddSingleton<TokenEndpointManager>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
