using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;


namespace LeaveManagementSystem_Backend.Services
{
    public class HolidayTypeService : IHolidayTypeService
    {
        private readonly IHolidayTypeRepository _holidayTypeRepository;

        public HolidayTypeService(IHolidayTypeRepository holidayTypeRepository)
        {
            _holidayTypeRepository = holidayTypeRepository;
        }
        public async Task<List<HolidayType>> GetHolidayTypes()
        {
            var res = await _holidayTypeRepository.GetHolidayTypes();
            return res;
        }



    }
}
