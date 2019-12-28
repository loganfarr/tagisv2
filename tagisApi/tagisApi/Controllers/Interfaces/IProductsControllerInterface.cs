using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IProductsControllerInterface
    {
        Task<ActionResult<IEnumerable<Product>>> GetProducts();
        Task<ActionResult<Product>> GetProduct(int id);
        Task<ActionResult<Product>> GetProductBySku(string sku);
        Task<ActionResult<IEnumerable<Product>>> GetLowStockProducts();
        bool updateProductStatus(string sku, int status);

        bool postProduct(Product product);
        bool uploadProductImage(FileStream image);

        bool updateProduct(Product product);
        bool updateProductBySku(Product product);
        Task<bool> UpdateProductInventory(int stock, string sku);
        Task<bool> CheckProductsAvailable(List<OrderItem> orderItems);

        Task<int> deleteProduct(Product product);
    }
}