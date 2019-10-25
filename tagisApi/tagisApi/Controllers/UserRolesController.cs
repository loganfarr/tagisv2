using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("roles")]
    public class UserRolesController : ControllerBase, IUserRolesController
    {
        private readonly TagisDbContext _context;

        public UserRolesController(TagisDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }
        
        // @todo Add function for adding roles
    }
}