using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("roles")]
    public class UserRolesController : ControllerBase, IUserRolesController
    {
        private readonly TagisDbContext _context;

        public UserRolesController(TagisDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public APIGatewayProxyResponse GetRoles()
        {
            List<UserRole> roleList = _context.UserRoles.ToList();
            return new TypedAPIGatewayProxyResponse<List<UserRole>>(200, roleList);
        }
        
        // @todo Add function for adding roles
    }
}