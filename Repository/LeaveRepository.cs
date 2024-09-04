using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly LMSDbContext _leaveContext;
        public LeaveRepository(LMSDbContext leaveContext)
        {
            _leaveContext = leaveContext;
        }

        public async Task<Leave> CreateLeave(Leave leave)
        {
            try
            {
                var res = _leaveContext.Leaves.Add(leave);
                await _leaveContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteLeave(int id)
        {
            var leave = await _leaveContext.Leaves.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (leave == null)
            {
                return "Requested ID not available ";
            }
            _leaveContext.Leaves.Remove(leave);
            await _leaveContext.SaveChangesAsync();
            return " suceeded";
        }

        public Task<Leave?> GetLeaveByID(int id)
        {
            try
            {
                var res = _leaveContext.Leaves.Where(x => x.Id == id).FirstOrDefault();

                return Task.FromResult(res);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Task<List<Leave>> GetLeaves()
        {
            try
            {
                var res = _leaveContext.Leaves.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<Leave> UpdateLeave(Leave leaveRequest)
        {
            try
            {
                var res = _leaveContext.Leaves.Update(leaveRequest);
                await _leaveContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Leave>> GetFilterLeaves(string searchTerm, int pageNumber, int pageSize)
        {
            var query = _leaveContext.Leaves.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(l =>
                    l.LeaveReason.Contains(searchTerm) ||
                    l.RejectReason.Contains(searchTerm) ||
                    l.Session.Contains(searchTerm) ||
                    l.EmployeeId.ToString().Contains(searchTerm) ||
                    l.UserId.ToString().Contains(searchTerm) ||
                    l.LeaveTypeId.ToString().Contains(searchTerm) ||
                    l.CoverPersonId.ToString().Contains(searchTerm)
                );
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetLeaveCountByStatusAsync(int status)
        {
            return await _leaveContext.Leaves
                .Where(l => l.LeaveStatus == status)
                .CountAsync();
        }
    }
}
