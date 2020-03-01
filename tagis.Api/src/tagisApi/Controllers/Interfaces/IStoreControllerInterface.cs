using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IStoreControllerInterface
    {
        APIGatewayProxyResponse GetStores();
        APIGatewayProxyResponse GetRecentStores();
        APIGatewayProxyResponse GetStoreByName(string name);
        APIGatewayProxyResponse GetStore(int id);
        APIGatewayProxyResponse GetStoreProducts(int storeId);
        APIGatewayProxyResponse GetStoreOrders(int storeId);
        
        APIGatewayProxyResponse PostStore(Store store);
        bool uploadStoreLogo(FileStream image);
    }
}