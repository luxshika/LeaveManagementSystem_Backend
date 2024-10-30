using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class HoildayTypeRepository : IHolidayTypeRepository
    {
        private readonly LMSDbContext _holidayTypeContext;
        public HoildayTypeRepository(LMSDbContext holidayTypeContext)
        {
            _holidayTypeContext = holidayTypeContext;
        }

        public Task<List<HolidayType>> GetHolidayTypes()
        {
            try
            {
                var res = _holidayTypeContext.Holidaytypes.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
