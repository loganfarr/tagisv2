using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            List<Store> recentStoreList = _context.Stores.OrderByDescending(c => c._cid).Take(5).ToList();
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
            throw new System.NotImplementedException();
//            return await _context.Products.Where(p => p.storeId == storeId).ToListAsync();
        }

        [HttpGet("orders")]
        public APIGatewayProxyResponse GetStoreOrders(int storeId)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public bool PostStore([FromBody] Store store)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("upload-logo")]
        public bool uploadStoreLogo([FromBody] FileStream image)
        {
            throw new System.NotImplementedException();
        }
    }
}