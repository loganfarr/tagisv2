using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagis.Controllers.Interfaces;
using tagis.Models;

namespace tagis.Controllers
{
    [Route("[controller]")]
    public class OrdersController : IOrdersControllerInterface
    {
        private DbContext _context;

        public OrdersController(DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> getAllOrders()
        {
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