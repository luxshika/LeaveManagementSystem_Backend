using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IHolidayRepository
    {
        Task<Holiday> CreateHoliday(Holiday holiday);
        Task<List<Holiday>> GetHolidays();
        Task<List<Holiday>> GetHolidayByID(int id);
        Task<Holiday> UpdateHoliday(Holiday holidayRequest);
        Task<string> DeleteHoliday(int id);
    }
}
