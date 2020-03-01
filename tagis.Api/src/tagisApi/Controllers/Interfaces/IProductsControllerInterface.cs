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

        APIGatewayProxyResponse UpdateProduct(Product product);
        APIGatewayProxyResponse UpdateProductBySku(Product product);
        Task<bool> UpdateProductInventory(int stock, string sku);
        Task<bool> CheckProductsAvailable(List<OrderItem> orderItems);

        APIGatewayProxyResponse DeleteProduct(Product product);
    }
}