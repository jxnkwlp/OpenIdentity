using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Services;
using OpenIdentity.Stores;
using OpenIdentity.Validation;

namespace OpenIdentity
{
    public class OpenIdentityOptionsBuilder
    {
        private readonly DefaultMemoryClientStore _clientStore = new DefaultMemoryClientStore();

        public IServiceCollection Services { get; }

        public OpenIdentityOptionsBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public OpenIdentityOptionsBuilder AddClientStore<T>() where T : class, IClientStore
        {
            Services.Replace(ServiceDescriptor.Transient<IClientStore, T>());
            return this;
        }

        public OpenIdentityOptionsBuilder AddClientValidator<T>() where T : class, IClientValidator
        {
            Services.Replace(ServiceDescriptor.Transient<IClientValidator, T>());
            return this;
        }

        public OpenIdentityOptionsBuilder AddJsonSerializer<T>() where T : class, IJsonSerializer
        {
            Services.Replace(ServiceDescriptor.Transient<IJsonSerializer, T>());
            return this;
        }

    }
}
