using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateHoliday(Holiday holidayRequest)
        {
            var res = await _holidayService.CreateHoliday(holidayRequest);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetHolidays()
        {
            var res = await _holidayService.GetHolidays();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHolidayByID(int id)
        {
            var res = await _holidayService.GetHolidayByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHoliday(Holiday holidayRequest)
        {
            var res = await _holidayService.UpdateHoliday(holidayRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHoliday(int id)
        {
            var res = await _holidayService.DeleteHoliday(id);
            return Ok(res);

        }
    }
}
