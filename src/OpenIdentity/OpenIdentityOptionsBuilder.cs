using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Stores;

namespace OpenIdentity
{
    public class OpenIdentityOptionsBuilder
    {
        private readonly DefaultMemoryClientStore _clientStore = new DefaultMemoryClientStore();

        public IServiceCollection ServiceCollection { get; }

        public OpenIdentityOptionsBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        public void AddClients(params Client[] clients)
        {
            // TODO , ClientMemoryStore.AddClient();
            //
            foreach (var client in clients)
                _clientStore.AddClient(client);
        }

        public OpenIdentityOptionsBuilder AddDefaultClientStore()
        {
            ServiceCollection.AddTransient<IClientStore, DefaultMemoryClientStore>();

            return this;
        }

        public OpenIdentityOptionsBuilder AddClientStore<T>() where T : IClientStore
        {
            var descriptor = new ServiceDescriptor(typeof(IClientStore), typeof(T), ServiceLifetime.Transient);
            ServiceCollection.Replace(descriptor);
            return this;
        }

        public OpenIdentityOptionsBuilder ReplaceService<TService, NewImplService>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var descriptor = new ServiceDescriptor(typeof(TService), typeof(NewImplService), lifetime);

            ServiceCollection.Replace(descriptor);

            return this;
        }
    }
}
