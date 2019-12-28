using System.Collections.Generic;
using System.IO;
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
    [Route("products")]
    public class ProductsController : Controller, IProductsControllerInterface
    {
        private readonly TagisDbContext _context;
        
        public ProductsController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }

        [HttpGet("sku/{sku}")]
        public async Task<ActionResult<Product>> GetProductBySku(string sku)
        {
            return await _context.Products.Where(p => p.Sku == sku).SingleOrDefaultAsync();
        }

        [HttpGet("lowStock")]
        public async Task<ActionResult<IEnumerable<Product>>> GetLowStockProducts()
        {
            return await _context.Products
                .Where(p => p.Stock > 0)
                .Include(p => p.Store)
                .OrderBy(p => p.Stock)
                .Take(5)
                .ToListAsync();
        }

        [HttpPut("update/{sku}/{status}")]
        public bool updateProductStatus(string sku, int status)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public bool postProduct([FromBody] Product product)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("upload-image")]
        public bool uploadProductImage([FromBody] FileStream image)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut]
        public bool updateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut("sku/{sku}")]
        public bool updateProductBySku(Product product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateProductInventory(int stock, string sku)
        {
            Product loadedProduct = await _context.Products.Where(p => p.Sku == sku).SingleOrDefaultAsync();

            if (loadedProduct == null) return false;

            loadedProduct.Stock += stock;

            _context.Attach(loadedProduct);
            _context.Entry(loadedProduct).Property("stock").IsModified = true;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> CheckProductsAvailable(List<OrderItem> orderItems)
        {
            List<string> requestedSkus = new List<string>();
            IDictionary<string, int> requestedProducts = new Dictionary<string, int>();
            foreach (var orderItem in orderItems)
            {
                requestedSkus.Add(orderItem.Sku);
                requestedProducts[orderItem.Sku] = orderItem.Quantity;
            }
            
            var loadedProducts = await _context.Products.Where(r => requestedSkus.Contains(r.Sku)).ToListAsync();

            return !requestedProducts.Where((t, i) => 
                loadedProducts.ElementAt(i).Stock < requestedProducts.ElementAt(i).Value).Any();
        }

        [HttpDelete]
        public async Task<int> deleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        private void processProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        private async Task<ActionResult<int>> GetStock(string sku)
        {
            var product = await _context.Products.Where(p => p.Sku == sku).Take(1).SingleOrDefaultAsync();
            return product.Stock;
        }
    }
}