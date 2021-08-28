using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIdentity.Endpoints;

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

            // core 
            services.AddOpenIdentityCore();

            // extensions
            // services.AddClientStore<ClientMemoryStore>();

            return builder;
        }

        private static void AddOpenIdentityCore(this IServiceCollection services)
        {
            services.AddTransient<AuthorizationEndpoint>();

        }

    }

    public static class OpenIdentityOptionsBuilderExtensions
    {

    }
}
