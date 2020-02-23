using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using tagisApi.Controllers.Interfaces;
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
        public APIGatewayProxyResponse GetProducts()
        {
            List<Product> productList = _context.Products.ToList();
            return new TypedAPIGatewayProxyResponse<List<Product>>(200, productList);
        }

        [HttpGet("id/{id}")]
        public APIGatewayProxyResponse GetProduct(int id)
        {
            Product product = _context.Products.Find(id);
            
            if (product == null)
            {
                return new APIGatewayProxyResponse {StatusCode = 404, Body = "Resource not found"};
            }

            return new TypedAPIGatewayProxyResponse<Product>(200, product);
        }

        [HttpGet("sku/{sku}")]
        public APIGatewayProxyResponse GetProductBySku(string sku)
        {
            Product product = _context.Products.SingleOrDefault(p => p.Sku == sku);
            return new TypedAPIGatewayProxyResponse<Product>(200, product);
        }

        [HttpGet("lowStock")]
        public APIGatewayProxyResponse GetLowStockProducts()
        {
            List<Product> lowStockProducts = _context.Products
                .Where(p => p.Stock > 0)
                .Include(p => p.Store)
                .OrderBy(p => p.Stock)
                .Take(5)
                .ToList();

            return new TypedAPIGatewayProxyResponse<List<Product>>(200, lowStockProducts);
        }

        [HttpPut("update/{sku}/{status}")]
        public APIGatewayProxyResponse UpdateProductStatus(string sku, int status)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public APIGatewayProxyResponse PostProduct([FromBody] Product product)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("upload-image")]
        public APIGatewayProxyResponse UploadProductImage([FromBody] FileStream image)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut("id/{id}")]
        public bool UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut("sku/{sku}")]
        public bool UpdateProductBySku(Product product)
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
        public async Task<int> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        private void ProcessProduct(Product product)
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