#if NETSTANDARD2_0
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace OpenIdentity.Services
{
    public class DefaultJsonSerializer : IJsonSerializer
    {
        public string Serializer<T>(T obj)
        {
#if NETSTANDARD2_0
            return JsonConvert.SerializeObject(obj);
#else
            return JsonSerializer.Serialize(obj);
#endif
        }
    }
}
