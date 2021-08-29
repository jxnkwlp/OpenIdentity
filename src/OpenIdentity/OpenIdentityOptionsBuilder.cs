using System;
using Microsoft.Extensions.DependencyInjection;
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

        public void RegisterClientStore<T>() where T : IClientStore
        {
            throw new NotImplementedException();
        }

        public OpenIdentityOptionsBuilder AddClients(params Client[] clients)
        {
            // TODO , ClientMemoryStore.AddClient();
            //

            throw new NotImplementedException();
        }

        public OpenIdentityOptionsBuilder AddClientStore<T>() where T : class, IClientStore, new()
        {
            ServiceCollection.AddTransient<IClientStore, T>();

            return this;
        }

        private void ReplaceService<TService>()
        {
            throw new NotImplementedException();
        }
    }
}
