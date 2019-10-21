using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IProductsControllerInterface
    {
        Task<ActionResult<IEnumerable<ProductResource>>> GetProducts();
        Task<ActionResult<ProductResource>> GetProduct(int id);
        Task<ActionResult<ProductResource>> GetProductBySku(string sku);
        Task<ActionResult<IEnumerable<ProductResource>>> GetLowStockProducts();
        bool updateProductStatus(string sku, int status);

        bool postProduct(Product product);
        bool uploadProductImage(FileStream image);

        bool updateProduct(Product product);
        bool updateProductBySku(Product product);
        Task<bool> UpdateProductInventory(int stock, string sku);
        Task<bool> CheckProductsAvailable(List<OrderItemResource> orderItems);

        Task<int> deleteProduct(ProductResource product);
    }
}