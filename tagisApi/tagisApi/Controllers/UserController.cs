using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class UserController : IUserController
    {
        public readonly TagisDbContext _context;

        public UserController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("authenticate")]
        public Task<ActionResult<bool>> Authenticate(string user, string password)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public Task<ActionResult<User>> PostUser(User user)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<User>> GetUser(int uid)
        {
            return await _context.Users.Where(u => u._uid == uid).SingleOrDefaultAsync();
        }

        [HttpPut]
        public Task<ActionResult<User>> UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        [HttpGet("roles")]
        public Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}