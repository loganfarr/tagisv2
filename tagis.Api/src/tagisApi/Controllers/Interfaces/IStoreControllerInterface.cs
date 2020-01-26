using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IStoreControllerInterface
    {
        Task<ActionResult<IEnumerable<Store>>> GetStores();
        Task<ActionResult<IEnumerable<Store>>> GetRecentStores();
        Task<ActionResult<Store>> GetStoreByName(string name);
        Task<ActionResult<Store>> GetStore(int id);
        Task<ActionResult<IEnumerable<Product>>> GetStoreProducts(int storeId);
        List<Order> GetStoreOrders(int storeId);
        
        bool PostStore(Store store);
        bool uploadStoreLogo(FileStream image);
    }
}