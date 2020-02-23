using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IProductsControllerInterface
    {
        APIGatewayProxyResponse GetProducts();
        APIGatewayProxyResponse GetProduct(int id);
        APIGatewayProxyResponse GetProductBySku(string sku);
        APIGatewayProxyResponse GetLowStockProducts();
        APIGatewayProxyResponse updateProductStatus(string sku, int status);

        APIGatewayProxyResponse postProduct(Product product);
        APIGatewayProxyResponse uploadProductImage(FileStream image);

        bool updateProduct(Product product);
        bool updateProductBySku(Product product);
        Task<bool> UpdateProductInventory(int stock, string sku);
        Task<bool> CheckProductsAvailable(List<OrderItem> orderItems);

        Task<int> deleteProduct(Product product);
    }
}