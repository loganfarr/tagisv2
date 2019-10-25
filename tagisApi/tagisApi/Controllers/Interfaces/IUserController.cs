using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IUserController
    {
//        Task<ActionResult<string>> Authenticate(string email, string password);

        Task<ActionResult<IEnumerable<User>>> GetUsers();

        Task<ActionResult<User>> PostUser([FromBody] User user);

        Task<ActionResult<User>> GetUser(int uid);

        Task<ActionResult<User>> UpdateUser([FromBody] User user);

        Task<ActionResult<int>> DeleteUser(User user);
    }
}