using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IHolidayService
    {
        Task<Holiday> CreateHoliday(Holiday holiday);
        Task<List<Holiday>> GetHolidays();
        Task<List<Holiday>> GetHolidayByID(int id);
        Task<Holiday> UpdateHoliday(Holiday holiday);
        Task<string> DeleteHoliday(int id);
    }
}
