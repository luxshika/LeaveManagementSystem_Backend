using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface ILeaveRepository
    {
        Task<Leave> CreateLeave(Leave leave);
        Task<List<Leave>> GetLeaves();

        //Task<List<Leave>> GetLeaves(string searchTerm, int pageNumber, int pageSize);
        Task<List<Leave>> GetFilterLeaves(string searchTerm, int pageNumber, int pageSize);
        Task<Leave?> GetLeaveByID(int id);
        Task<Leave> UpdateLeave(Leave leaveRequest);
        Task<string> DeleteLeave(int id);
        Task<int> GetLeaveCountByStatusAsync(int status);
    }
}
