using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IUserRolesController
    {
        APIGatewayProxyResponse GetRoles();
    }
}