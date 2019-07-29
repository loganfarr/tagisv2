using System.Collections.Generic;
using System.IO;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IStoreControllerInterface
    {
        List<Store> getAllStores();
        List<Store> getStoreList();
        List<Store> getRecentStores();
        Store getStoreByName(string name);
        Store getStore(int id);
        List<Product> getStoreProducts();
        List<Order> getStoreOrders();
        
        bool postStore(Store store);
        bool uploadStoreLogo(FileStream image);
    }
}