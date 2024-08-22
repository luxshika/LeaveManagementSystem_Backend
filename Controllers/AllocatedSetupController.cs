using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AllocatedSetupController  : ControllerBase
    {
        private readonly IAllocatedSetupService _allocatedSetupService;

        public AllocatedSetupController(IAllocatedSetupService allocatedSetupService)
        {
            _allocatedSetupService = allocatedSetupService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateAllocatedSetup(AllocatedSetup allocatedSetup)
        {
            var res = await _allocatedSetupService.CreateAllocatedSetup(allocatedSetup);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllocatedSetups()
        {
            var res = await _allocatedSetupService.GetAllocatedSetups();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllocatedSetupByID(int id)
        {
            var res = await _allocatedSetupService.GetAllocatedSetupByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAllocatedSetup(AllocatedSetup allocatedSetupRequest)
        {
            var res = await _allocatedSetupService.UpdateAllocatedSetup(allocatedSetupRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAllocatedSetup(int id)
        {
            var res = await _allocatedSetupService.DeleteAllocatedSetup(id);
            return Ok(res);

        }

    }
}
