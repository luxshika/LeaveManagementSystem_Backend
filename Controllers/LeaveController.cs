using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeave([FromBody] Leave leaveRequest)
        {
            try
            {
                var result = await _leaveService.CreateLeave(leaveRequest);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetLeaves()
        {
            try
            {
                var result = await _leaveService.GetLeaves();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLeaveByID(int id)
        {
            try
            {
                var result = await _leaveService.GetLeaveByID(id);
                if (result == null)
                {
                    return NotFound(new { message = "Leave not found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLeave([FromBody] Leave leaveRequest)
        {
            try
            {
                var result = await _leaveService.UpdateLeave(leaveRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeave(int id)
        {
            try
            {
                var result = await _leaveService.DeleteLeave(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}/leavestatus")]
        public async Task<ActionResult> UpdateLeaveStatus(int id, [FromBody] UpdateLeaveStatusDto updateDto)
        {
            try
            {
                var success = await _leaveService.UpdateLeaveStatus(id, updateDto.NewStatus, updateDto.RejectReason);
                if (success)
                {
                    return NoContent();
                }
                return NotFound(new { message = "Leave not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult> FilterLeave([FromQuery] int coverPersonId, [FromQuery] DateTime beginDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var result = await _leaveService.FilterLeave(coverPersonId, beginDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Leave>>> GetFilterLeaves(string searchTerm = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var leaves = await _leaveService.GetFilterLeaves(searchTerm, pageNumber, pageSize);
                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("count/unread")]
    public async Task<IActionResult> GetLeaveCountWithStatusUnRead()
    {
        var count = await _leaveService.GetLeaveCountWithStatusUnReadAsync();
        return Ok(count);
    }
    }
}
