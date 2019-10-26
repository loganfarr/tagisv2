using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tagisApi.Authentication.Interfaces;

namespace tagisApi.Authentication
{
    public class InMemoryGetAllApiKeysQuery : IGetAllApiKeysQuery
    {
        public Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync()
        {
            var apiKeys = new List<ApiKey>
            {
                new ApiKey(1, "Tagis", "s86ThAy9v4O52d907l12I01sN215bD8i5q1a41474t43axB5X68b2c16691c",
                    new DateTime(2019, 10, 26), new List<string> {"client"})
            };

            IReadOnlyDictionary<string, ApiKey> readonlyDictionary = apiKeys.ToDictionary(x => x.Key, x => x);
            return Task.FromResult(readonlyDictionary);
        }
    }
}