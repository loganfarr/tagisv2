using System.Collections.Generic;
using System.IO;
using tagis.Models;

namespace tagis.Controllers.Interfaces
{
    public interface IStoreControllerInterface
    {
        List<Store> getAllStores();
        List<Store> getStoreList();
        List<Store> getRecentStores();
        Store getStoreByName(string title);
        Store getStore(int id);
        List<Product> getStoreProducts();
        List<Order> getStoreOrders();
        
        bool postStore(Store store);
        bool uploadStoreLogo(FileStream image);
    }
}