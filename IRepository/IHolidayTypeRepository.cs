using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IHolidayTypeRepository
    {
        Task<List<HolidayType>> GetHolidayTypes();
    }
}
