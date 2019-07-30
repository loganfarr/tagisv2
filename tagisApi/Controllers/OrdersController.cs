using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ControllerBase, IOrdersControllerInterface
    {
        private readonly TagisDbContext _context;
        private readonly IMapper _mapper;
        public OrdersController(TagisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetOrders()
        {
            Console.WriteLine("Getting orders.....");
            
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("list")]
        public List<Order> getOrderList()
        {
            throw new System.NotImplementedException();
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResource>> getOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();
            
            return order;
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