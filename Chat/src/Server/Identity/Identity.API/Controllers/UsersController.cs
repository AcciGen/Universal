using Identity.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
            => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(_context.Users.ToList());
        }
    }
}
