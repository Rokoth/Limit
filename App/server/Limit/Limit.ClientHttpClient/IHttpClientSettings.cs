using System;
using System.Collections.Generic;

namespace Limit.ClientHttpClient
{
    public interface IHttpClientSettings
    {
        Dictionary<Type, string> Apis { get; }
        string Server { get; }
    }
}
