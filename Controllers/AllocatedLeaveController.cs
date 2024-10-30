using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocatedLeaveController : ControllerBase
    {
        private readonly IAllocatedLeaveService _allocatedleaveService;
        public AllocatedLeaveController(IAllocatedLeaveService allocatedleaveService)
        {
            _allocatedleaveService = allocatedleaveService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAllocatedLeave(AllocatedLeave allocatedleaveRequest)
        {
            var res = await _allocatedleaveService.CreateAllocatedLeave(allocatedleaveRequest);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllocatedLeaves()
        {

            var res = await _allocatedleaveService.GetAllocatedLeaves();
            return Ok(res);
        }

        [HttpGet("{employeeId}/{leaveTypeId}")]
        public async Task<ActionResult> GetAllocatedLeaveByID(int employeeId, int leaveTypeId)
        {
            var res = await _allocatedleaveService.GetAllocatedLeaveByID(employeeId, leaveTypeId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpGet("{employeeId}")]
        public async Task<ActionResult> GetAllocatedLeaveEmployeeByID(int employeeId)
        {
            var res = await _allocatedleaveService.GetAllocatedLeaveEmployeeByID(employeeId);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAllocatedLeave(AllocatedLeave allocatedLeaveRequest)
        {
            var res = await _allocatedleaveService.UpdateAllocatedLeave(allocatedLeaveRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAllocatedLeave(int id)
        {
            var res = await _allocatedleaveService.DeleteAllocatedLeave(id);
            return Ok(res);

        }
    }
}
