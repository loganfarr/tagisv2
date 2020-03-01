using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;
using Amazon.Lambda.APIGatewayEvents;

namespace tagisApi.Controllers.Interfaces
{
    public interface IOrdersControllerInterface
    {
        // Get functions
        APIGatewayProxyResponse GetOrders();
        APIGatewayProxyResponse getOrderList();
        APIGatewayProxyResponse GetOrder(int id);
        APIGatewayProxyResponse getRecentOrders();
        
        Task<ActionResult<bool>> PostOrder(Order order);
        
        APIGatewayProxyResponse updateOrder(Order order);
        
        APIGatewayProxyResponse deleteOrder(Order order);

        APIGatewayProxyResponse patchOrder(Order order);
    }
}