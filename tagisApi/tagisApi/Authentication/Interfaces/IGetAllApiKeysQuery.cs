using System.Collections.Generic;
using System.Threading.Tasks;

namespace tagisApi.Authentication.Interfaces
{
    public interface IGetAllApiKeysQuery
    {
        Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync();
    }
}