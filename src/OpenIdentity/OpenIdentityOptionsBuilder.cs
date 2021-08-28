using Microsoft.Extensions.DependencyInjection;
using OpenIdentity.Abstractions;
using OpenIdentity.Abstractions.Stores;
using OpenIdentity.Stores;

namespace OpenIdentity
{
    public class OpenIdentityOptionsBuilder
    {
        ClientMemoryStore _clientStore = new ClientMemoryStore();

        public IServiceCollection ServiceCollection { get; }

        public OpenIdentityOptionsBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        public void RegisterClientStore<T>() where T : IClientStore
        {

        }

        public OpenIdentityOptionsBuilder AddClients(params Client[] clients)
        {
            // TODO , ClientMemoryStore.AddClient();
            //


            return this;
        }

        public   OpenIdentityOptionsBuilder AddClientStore<T>( ) where T : class, IClientStore, new()
        {
            ServiceCollection.AddTransient<IClientStore, T>();

            return this;
        }

        private void ReplaceService<TService>()
        {

        }
    }
}
