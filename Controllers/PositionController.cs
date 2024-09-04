using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController
    {
    
        private readonly LMSDbContext _context;

        public PositionController(LMSDbContext context)
        {
            _context = context;
        }
  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
