using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IAllocatedLeaveService
    {
        Task<AllocatedLeave> CreateAllocatedLeave(AllocatedLeave allocatedLeave);
        Task<List<AllocatedLeave>> GetAllocatedLeaves();
        Task<AllocatedLeave?> GetAllocatedLeaveByID(int employeeid , int leavetypeid);
        Task<AllocatedLeave> UpdateAllocatedLeave(AllocatedLeave allocatedLeave);
        Task<string> DeleteAllocatedLeave(int id);
        Task AllocateAnnualLeave(Employee employee);

        Task AllocatedCasualLeave(Employee employee);


    }
}
