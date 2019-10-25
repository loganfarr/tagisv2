using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly TagisDbContext _context;

        public UserController(TagisDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate([FromBody] UserAuthenticationResource user)
        {
//            Console.WriteLine("User authentication attempted: " + user.email);
//            return user;
            
            var loadedUser = await _context.Users.Where(u => u.Email == "logan@loganfarr.com")
                .SingleOrDefaultAsync();

            // @todo: Add JWT logic here
//            return loadedUser != null;
            return loadedUser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new {id = user._uid}, user);
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
    }
}