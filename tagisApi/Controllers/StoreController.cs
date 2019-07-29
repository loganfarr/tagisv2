using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller, IStoreControllerInterface
    {
        [HttpGet]
        public List<Store> getAllStores()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("list")]
        public List<Store> getStoreList()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("recent")]
        public List<Store> getRecentStores()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("name/{name}")]
        public Store getStoreByName(string name)
        {
            throw new System.NotImplementedException();
        }
        
        [HttpGet("{id}")]
        public Store getStore(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("products")]
        public List<Product> getStoreProducts()
        {
            throw new System.NotImplementedException();
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