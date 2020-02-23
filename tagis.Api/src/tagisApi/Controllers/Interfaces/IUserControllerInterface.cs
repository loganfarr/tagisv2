using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;
using tagisApi.Models.ResourceModels;

namespace tagisApi.Controllers.Interfaces
{
    public interface IUserControllerInterface
    {
        APIGatewayProxyResponse Authenticate([FromBody] UserAuthenticationResource user);

        APIGatewayProxyResponse GetUsers();

        APIGatewayProxyResponse PostUser([FromBody] User user);

        APIGatewayProxyResponse GetUser(int uid);

        APIGatewayProxyResponse UpdateUser([FromBody] User user);

        APIGatewayProxyResponse DeleteUser(User user);
    }
}