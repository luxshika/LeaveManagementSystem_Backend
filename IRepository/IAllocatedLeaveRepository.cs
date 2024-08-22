using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IAllocatedLeaveRepository
    {

        Task<AllocatedLeave> CreateAllocatedLeave(AllocatedLeave allocatedLeave);
        Task<AllocatedLeave?> GetAllocatedLeave(int? employeeId, int leaveTypeId);
        Task<AllocatedLeave> UpdateAllocatedLeave(AllocatedLeave allocatedLeaveRequest);
        Task<string> DeleteAllocatedLeave(int id);
        Task<List<AllocatedLeave>> GetAllocatedLeaves();

    }
}
