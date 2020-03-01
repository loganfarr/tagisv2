using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("store")]
    public class StoreController : Controller, IStoreControllerInterface
    {
        private readonly TagisDbContext _context;

        public StoreController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public APIGatewayProxyResponse GetStores()
        {
            List<Store> storeList = _context.Stores.ToList();
            return new TypedAPIGatewayProxyResponse<List<Store>>(200, storeList);
        }
        
        [HttpGet("recent")]
        public APIGatewayProxyResponse GetRecentStores()
        {
            List<Store> recentStoreList = _context.Stores.OrderByDescending(c => c.Id).Take(5).ToList();
            return new TypedAPIGatewayProxyResponse<List<Store>>(200, recentStoreList);
        }

        [HttpGet("name/{name}")]
        public APIGatewayProxyResponse GetStoreByName(string name)
        {
            Store store = _context.Stores.SingleOrDefault(c => c.Title == name);
            return new TypedAPIGatewayProxyResponse<Store>(200, store);
        }
        
        [HttpGet("{id}")]
        public APIGatewayProxyResponse GetStore(int id)
        {
            Store store = _context.Stores.Find(id);
            return new TypedAPIGatewayProxyResponse<Store>(200, store);
        }

        [HttpGet("products/{id}")]
        public APIGatewayProxyResponse GetStoreProducts(int storeId)
        {
            // throw new System.NotImplementedException();
            List<Product> productList = _context.Products
                .Include(p => p.Store)
                .Where(p => p.Store.Id == storeId)
                .ToList();
            
            return new TypedAPIGatewayProxyResponse<List<Product>>(200, productList);
        }

        [HttpGet("orders")]
        public APIGatewayProxyResponse GetStoreOrders(int storeId)
        {
            List<Order> orderList = _context.Orders
                .Include(o => o.Store)
                .Where(o => o.Store.Id == storeId)
                .ToList();
            
            return new TypedAPIGatewayProxyResponse<List<Order>>(200, orderList);
        }

        [HttpPost]
        public APIGatewayProxyResponse PostStore([FromBody] Store store)
        {
            _context.Add(store);
            _context.SaveChanges();
            CreatedAtActionResult createdStore = CreatedAtAction(nameof(GetStore), new { id=store.Id}, store);
            return new TypedAPIGatewayProxyResponse<CreatedAtActionResult>(200, createdStore);
        }

        [HttpPost("upload-logo")]
        public bool uploadStoreLogo([FromBody] FileStream image)
        {
            throw new System.NotImplementedException();
        }
    }
}