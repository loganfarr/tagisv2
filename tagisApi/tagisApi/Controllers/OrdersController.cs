using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase, IOrdersControllerInterface
    {
        private readonly TagisDbContext _context;
        private readonly IProductsControllerInterface _productsController;
        public OrdersController(TagisDbContext context, IProductsControllerInterface productsController)
        {
            _context = context;
            _productsController = productsController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<OrderShortResource>>> getOrderList()
        {
            return await _context.Orders.Select(o => new OrderShortResource
            {
                _oid = o._oid,
                Total = o.Total,
                OrderStatus = o.OrderStatus
            }).ToListAsync();
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResource>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            order.Products = GetOrderItems(id);

            return order;
        }

        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> getRecentOrders()
        {
            return await _context.Orders.OrderByDescending(o => o.CreatedDate).Take(10).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostOrder([FromBody] OrderResource order)
        {
            if (!await _productsController.CheckProductsAvailable(order.Products))
                return false;
            
            foreach (var product in order.Products)
            {
                // Decrement inventory since it's a new order
                await _productsController.UpdateProductInventory(product.Quantity * -1, product.Sku);
            }
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            
            // @todo send order email receipt and notifications
            
            return CreatedAtAction(nameof(GetOrder), new {id = order._oid}, order);
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

        private List<OrderItemResource> GetOrderItems(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderResourceOid == orderId).ToList();
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