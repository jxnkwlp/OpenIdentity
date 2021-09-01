using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIdentity.Services
{
    public interface IJsonSerializer
    {
        string Serializer<T>(T obj);
            
    }
}
