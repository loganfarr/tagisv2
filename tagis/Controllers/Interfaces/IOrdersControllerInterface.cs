using System.Collections.Generic;
using tagis.Models;

namespace tagis.Controllers.Interfaces
{
    public interface IOrdersControllerInterface
    {
        // Get functions
        List<Order> getAllOrders();
        List<Order> getOrderList();
        Order getOrder();
        List<Order> getRecentOrders();
        
        bool postOrder(Order order);
        
        bool updateOrder(Order order);
        
        bool deleteOrder(Order order);

        bool patchOrder(Order order);
    }
}