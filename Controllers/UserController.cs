using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LMSDbContext _usercontext;

        public UserController(LMSDbContext usercontext)
        {
            _usercontext = usercontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usercontext.Users.ToListAsync();
        }

    }
}
