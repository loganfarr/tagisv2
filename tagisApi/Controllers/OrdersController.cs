using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;
using tagisApi.Persistence;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller, IOrdersControllerInterface
    {
        private readonly TagisDbContext _context;
        public OrdersController(TagisDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
//            return await _context.Orders.Include(o => o.Models).ToList();
            throw new System.NotImplementedException();
        }

        [HttpGet("list")]
        public List<Order> getOrderList()
        {
            throw new System.NotImplementedException();
        }
    
        [HttpGet("{id}")]
        public Order getOrder()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("recent")]
        public List<Order> getRecentOrders()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public bool postOrder([FromBody] Order order)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut]
        public bool updateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        public bool deleteOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        [HttpPatch]
        public bool patchOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        private void processOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        private void postOrderUpdate(Order order)
        {
            throw new System.NotImplementedException();
        }

        private void checkProductStock(List<string> skus)
        {
            throw new System.NotImplementedException();
        }

        private void deductProductStock(List<string> skus)
        {
            throw new System.NotImplementedException();
        }
    }
}