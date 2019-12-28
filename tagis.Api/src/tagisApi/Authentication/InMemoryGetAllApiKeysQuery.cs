using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using tagisApi.Authentication.Interfaces;

namespace tagisApi.Authentication
{
    public class InMemoryGetAllApiKeysQuery : IGetAllApiKeysQuery
    {
        private readonly IConfiguration _config;
        public InMemoryGetAllApiKeysQuery(IConfiguration config)
        {
            _config = config;
        }
        public Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync()
        {
            var apiKeys = new List<ApiKey>
            {
                new ApiKey(1, "Tagis", _config.GetValue<string>("Authorization:TagisApiKey"),
                    new DateTime(2019, 10, 26), new List<string> {"client"})
            };

            IReadOnlyDictionary<string, ApiKey> readonlyDictionary = apiKeys.ToDictionary(x => x.Key, x => x);
            return Task.FromResult(readonlyDictionary);
        }
    }
}