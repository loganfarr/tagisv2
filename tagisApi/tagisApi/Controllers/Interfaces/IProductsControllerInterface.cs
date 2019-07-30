using System.Collections.Generic;
using System.IO;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IProductsControllerInterface
    {
        List<Product> getAllProducts();
        List<Product> getProductList();
        Product getProduct();
        List<Product> getProductsBySku();
        List<Product> getLowStockProducts();
        bool updateProductStatus(string sku, int status);

        bool postProduct(Product product);
        bool uploadProductImage(FileStream image);

        bool updateProduct(Product product);
        bool updateProductBySku(Product product);
        int updateProductInventory(int stock, string sku);

        bool deleteProduct(Product product);
    }
}