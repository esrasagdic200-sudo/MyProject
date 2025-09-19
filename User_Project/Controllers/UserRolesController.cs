using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProject.Core.Models;
using UserProject.Data;

namespace UserProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController:ControllerBase
    {
        private readonly AppDbContext _context;

        public UserRolesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            var role = new UserRole { RoleName = name };
            _context.UserRoles.Add(role);
            await _context.SaveChangesAsync();
            return Ok(role);
        }
    }
}
