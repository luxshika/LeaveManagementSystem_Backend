using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeam(Team teamRequest)
        {
            var res = await _teamService.CreateTeam(teamRequest);
            return Ok(res);
        }


        [HttpGet]
        public async Task<ActionResult> GetTeams()
        {
            var res = await _teamService.GetTeams();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeamByID(int id)
        {
            var res = await _teamService.GetTeamByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTeam(Team teamRequest)
        {
            var res = await _teamService.UpdateTeam(teamRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            var res = await _teamService.DeleteTeam(id);
            return Ok(res);

        }
        [HttpPost("{teamId}/employees/{employeeId}")]
        public async Task<IActionResult> AddEmployeeToTeam(int teamId, int employeeId)
        {
            await _teamService.AddEmployeeToTeamAsync(teamId, employeeId);
            return NoContent();
        }

        [HttpDelete("{teamId}/employees/{employeeId}")]
        public async Task<IActionResult> RemoveEmployeeFromTeam(int teamId, int employeeId)
        {
            await _teamService.RemoveEmployeeFromTeamAsync(teamId, employeeId);
            return NoContent();
        }

    }
}
