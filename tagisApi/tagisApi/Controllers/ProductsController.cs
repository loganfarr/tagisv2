using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller, IProductsControllerInterface
    {
        private readonly TagisDbContext _context;
        
        public ProductsController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return product;
        }

        [HttpGet("sku/{sku}")]
        public async Task<ActionResult<ProductResource>> GetProductBySku(string sku)
        {
            return await _context.Products.Where(p => p.sku == sku).SingleOrDefaultAsync();
        }

        [HttpGet("lowStock")]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetLowStockProducts()
        {
            return await _context.Products.Where(p => p.stock > 0).OrderBy(p => p.stock).Take(5).ToListAsync();
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

        [HttpPut("stock/{sku}/{stock}")]
        public int updateProductInventory(int stock, string sku)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        public bool deleteProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        private void processProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        private async Task<ActionResult<int>> GetStock(string sku)
        {
            var product = await _context.Products.Where(p => p.sku == sku).Take(1).SingleOrDefaultAsync();
            return product.stock;
        }
    }
}