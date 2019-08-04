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
        Task<ActionResult<IEnumerable<StoreResource>>> GetStores();
        Task<ActionResult<IEnumerable<StoreResource>>> GetRecentStores();
        Task<ActionResult<StoreResource>> GetStoreByName(string name);
        Task<ActionResult<StoreResource>> GetStore(int id);
        Task<ActionResult<IEnumerable<ProductResource>>> GetStoreProducts(int storeId);
        List<Order> getStoreOrders();
        
        bool postStore(Store store);
        bool uploadStoreLogo(FileStream image);
    }
}