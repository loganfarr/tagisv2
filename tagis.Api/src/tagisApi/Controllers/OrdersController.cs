using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;
using tagisApi.Lambda;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace tagisApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase, IOrdersControllerInterface
    {
        
        private readonly TagisDbContext _context;
        private readonly IProductsControllerInterface _productsController;

        public OrdersController()
        {
            string connectionString = LambdaConfiguration.GetDatabaseCreds();

            var optionsBuilder = new DbContextOptionsBuilder<TagisDbContext>();

            optionsBuilder.UseMySQL(connectionString);

            _context = new TagisDbContext(optionsBuilder.Options);
        }
        
        public OrdersController(TagisDbContext context, IProductsControllerInterface productsController)
        {
            _context = context;
            _productsController = productsController;
        }

        [HttpGet]
        public APIGatewayProxyResponse GetOrders()
        {
            var orderList = _context.Orders.OrderByDescending(o => o.CreatedDate).ToListAsync();
            var response = new APIGatewayProxyResponse {StatusCode = 200, Body = JsonConvert.SerializeObject(orderList)};
            return response;
        }

        [HttpGet("list")]
        public APIGatewayProxyResponse getOrderList()
        {
            var orderList = _context.Orders
                .Include(o => o.Store)
                .OrderByDescending(o => o.CreatedDate)
                .ToListAsync();
            return new APIGatewayProxyResponse { StatusCode = 200, Body = JsonConvert.SerializeObject(orderList)};
        }
    
        [HttpGet("{id}")]
        public APIGatewayProxyResponse GetOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.Store)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o._oid == id);

            return order == null ? new APIGatewayProxyResponse {StatusCode = 404, Body = null} : new APIGatewayProxyResponse { StatusCode = 200, Body = JsonConvert.SerializeObject(order)};
        }

        [HttpGet("recent")]
        public APIGatewayProxyResponse getRecentOrders()
        {
            var orders = _context.Orders
                .Include(o => o.Store)
                .OrderByDescending(o => o.CreatedDate)
                .Take(10)
                .ToListAsync();
            
            return new APIGatewayProxyResponse { StatusCode = 200, Body = JsonConvert.SerializeObject(orders) };
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostOrder([FromBody] Order order)
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

        private List<OrderItem> GetOrderItems(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.Order_oid == orderId).ToList();
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