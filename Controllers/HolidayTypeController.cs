using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayTypeController : ControllerBase
    {
        private readonly IHolidayTypeService _holidayTypeService;
        public HolidayTypeController(IHolidayTypeService holidayTypeService)

        {
            _holidayTypeService = holidayTypeService;
        }
        [HttpGet]
        public async Task<ActionResult> GetHolidayTypes()
        {
            var res = await _holidayTypeService.GetHolidayTypes();
            return Ok(res);
        }

    }
    
}
