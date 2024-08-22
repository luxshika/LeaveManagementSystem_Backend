using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly LMSDbContext _leaveTypecontext;

        public LeaveTypeController(LMSDbContext leaveTypecontext)
        {
            _leaveTypecontext = leaveTypecontext;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveType>>> GetLeaveTypes()
        {
            return await _leaveTypecontext.leavetypes.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveType>> GetLeaveType(int id)
        {
            var leaveType = await _leaveTypecontext.leavetypes.FindAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            return leaveType;
        }
       
    }
}

