using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class AllocatedSetupRepository : IAllocatedSetupRepository
    {
        private readonly LMSDbContext _allocatedSetupContext;
        public AllocatedSetupRepository(LMSDbContext allocatedSetupContext)
        {
            _allocatedSetupContext = allocatedSetupContext;
        }

        public async Task<AllocatedSetup> CreateAllocatedSetup(AllocatedSetup allocatedSetup)
        {
            try
            {
                var res = _allocatedSetupContext.AllocatedSetups.Add(allocatedSetup);
                await _allocatedSetupContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteAllocatedSetup(int id)
        {
            var allocatedSetup = await _allocatedSetupContext.AllocatedSetups.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (allocatedSetup == null)
            {
                return "Requested ID not available ";
            }
            _allocatedSetupContext.AllocatedSetups.Remove(allocatedSetup);
            await _allocatedSetupContext.SaveChangesAsync();
            return " suceeded";
        }

        public async Task<List<AllocatedSetup>> GetAllocatedSetupByID(int id)
        {
            try
            {

                var res = await _allocatedSetupContext.AllocatedSetups.Where(x => x.Id == id).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<List<AllocatedSetup>> GetAllocatedSetups()
        {
            try
            {
                var res = _allocatedSetupContext.AllocatedSetups.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<AllocatedSetup> UpdateAllocatedSetup(AllocatedSetup allocatedSetupRequest)
        {
            try
            {
                var res = _allocatedSetupContext.AllocatedSetups.Update(allocatedSetupRequest);
                await _allocatedSetupContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
