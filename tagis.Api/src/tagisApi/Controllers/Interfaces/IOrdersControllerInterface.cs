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
        Task<ActionResult<IEnumerable<Order>>> GetOrders();
        Task<ActionResult<IEnumerable<Order>>> getOrderList();
        Task<ActionResult<Order>> GetOrder(int id);
        Task<ActionResult<IEnumerable<Order>>> getRecentOrders();
        
        Task<ActionResult<bool>> PostOrder(Order order);
        
        bool updateOrder(Order order);
        
        bool deleteOrder(Order order);

        bool patchOrder(Order order);
    }
}