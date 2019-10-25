using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tagisApi.Models;

namespace tagisApi.Controllers.Interfaces
{
    public interface IUserRolesController
    {
        Task<ActionResult<IEnumerable<UserRole>>> GetRoles();
    }
}