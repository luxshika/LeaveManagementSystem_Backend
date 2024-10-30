using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IHolidayTypeService
    {
        Task<List<HolidayType>> GetHolidayTypes();
    }
}
