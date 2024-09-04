using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class AllocatedLeaveRepository : IAllocatedLeaveRepository
    {
        private readonly LMSDbContext _allocatedleavecontext;
        public AllocatedLeaveRepository(LMSDbContext allocatedleavecontext)
        {
            _allocatedleavecontext = allocatedleavecontext;
        }
        public async Task<AllocatedLeave> CreateAllocatedLeave(AllocatedLeave allocatedLeave)
        {
            try
            {
                var res = _allocatedleavecontext.AllocatedLeaves.Add(allocatedLeave);
                await _allocatedleavecontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> DeleteAllocatedLeave(int id)
        {
            var allocatedleave = await _allocatedleavecontext.AllocatedLeaves.Where(x => x.LeaveId == id).FirstOrDefaultAsync();
            if (allocatedleave == null)
            {
                return "Requested ID not available ";
            }
            _allocatedleavecontext.AllocatedLeaves.Remove(allocatedleave);
            await _allocatedleavecontext.SaveChangesAsync();
            return " suceeded";
        }

        public async Task<AllocatedLeave?> GetAllocatedLeave(int? employeeId, int leaveTypeId)
        {
            return await _allocatedleavecontext.AllocatedLeaves
                .FirstOrDefaultAsync(al => al.EmployeeId == employeeId && al.LeaveTypeId == leaveTypeId);
        }

        public Task<List<AllocatedLeave>> GetAllocatedLeaves()
        {
            try
            {
                var res = _allocatedleavecontext.AllocatedLeaves.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AllocatedLeave> UpdateAllocatedLeave(AllocatedLeave allocatedLeaveRequest)
        {
            try
            {
                var res = _allocatedleavecontext.AllocatedLeaves.Update(allocatedLeaveRequest);
                await _allocatedleavecontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
