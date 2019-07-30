using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller, IProductsControllerInterface
    {
        [HttpGet]
        public List<Product> getAllProducts()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("list")]
        public List<Product> getProductList()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}")]
        public Product getProduct()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("sku/{sku}")]
        public List<Product> getProductsBySku()
        {
            throw new System.NotImplementedException();
        }

        public int checkStock(string sku)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("lowStock")]
        public List<Product> getLowStockProducts()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("update/{sku}/{status}")]
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

        [HttpGet("stock/{sku}/{stock}")]
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
    }
}