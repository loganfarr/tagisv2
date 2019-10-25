using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller, IStoreControllerInterface
    {
        private readonly TagisDbContext _context;

        public StoreController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<StoreResource>>>  GetStores()
        {
            return await _context.Stores.ToListAsync();
        }
        
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<StoreResource>>> GetRecentStores()
        {
            return await _context.Stores.OrderByDescending(c => c._cid).Take(5).ToListAsync();
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<StoreResource>> GetStoreByName(string name)
        {
            return await _context.Stores.Where(c => c.Title == name).SingleOrDefaultAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreResource>> GetStore(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

        [HttpGet("products")]
        public Task<ActionResult<IEnumerable<ProductResource>>> GetStoreProducts(int storeId)
        {
            throw new System.NotImplementedException();
//            return await _context.Products.Where(p => p.storeId == storeId).ToListAsync();
        }

        [HttpGet("orders")]
        public List<Order> getStoreOrders()
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public bool postStore([FromBody] Store store)
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