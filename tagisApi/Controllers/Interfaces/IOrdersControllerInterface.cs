using System.Collections.Generic;
using System.Threading.Tasks;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IOrdersControllerInterface
    {
        // Get functions
        Task<IEnumerable<Order>> GetOrders();
        List<Order> getOrderList();
        Order getOrder();
        List<Order> getRecentOrders();
        
        bool postOrder(Order order);
        
        bool updateOrder(Order order);
        
        bool deleteOrder(Order order);

        bool patchOrder(Order order);
    }
}