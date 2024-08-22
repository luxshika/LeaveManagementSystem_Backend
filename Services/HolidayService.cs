using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.Services
{
    public class HolidayService:IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }
        public async Task<Holiday> CreateHoliday(Holiday holiday)
        {

            return await _holidayRepository.CreateHoliday(holiday);
        }

        public async Task<string> DeleteHoliday(int id)
        {
            var res = await _holidayRepository.DeleteHoliday(id);
            return res;
        }

        public async Task<List<Holiday>> GetHolidayByID(int id)
        {
            var res = await _holidayRepository.GetHolidayByID(id);
            return res;
        }

        public async Task<List<Holiday>> GetHolidays()
        {
            var res = await _holidayRepository.GetHolidays();
            return res;
        }



        public async Task<Holiday> UpdateHoliday(Holiday holidayRequest)
        {
            var res = await _holidayRepository.UpdateHoliday(holidayRequest);
            return res;
        }

      
    }
}
