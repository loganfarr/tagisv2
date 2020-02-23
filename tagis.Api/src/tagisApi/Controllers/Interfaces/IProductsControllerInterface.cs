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
        APIGatewayProxyResponse UpdateProductStatus(string sku, int status);

        APIGatewayProxyResponse PostProduct(Product product);
        APIGatewayProxyResponse UploadProductImage(FileStream image);

        bool UpdateProduct(Product product);
        bool UpdateProductBySku(Product product);
        Task<bool> UpdateProductInventory(int stock, string sku);
        Task<bool> CheckProductsAvailable(List<OrderItem> orderItems);

        Task<int> DeleteProduct(Product product);
    }
}