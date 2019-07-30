using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IOrdersControllerInterface
    {
        // Get functions
        Task<ActionResult<IEnumerable<OrderResource>>> GetOrders();
        List<Order> getOrderList();
        Task<ActionResult<OrderResource>> getOrder(int id);
        List<Order> getRecentOrders();
        
        bool postOrder(Order order);
        
        bool updateOrder(Order order);
        
        bool deleteOrder(Order order);

        bool patchOrder(Order order);
    }
}