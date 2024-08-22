using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface ILeaveService
    {
        Task<Leave> CreateLeave(Leave leave);
        Task<List<Leave>> GetLeaves();
       

        Task<List<Leave>> GetFilterLeaves(string searchTerm, int pageNumber, int pageSize);
        Task<Leave?> GetLeaveByID(int id);
        Task<Leave> UpdateLeave(Leave leaveRequest);
        Task<string> DeleteLeave(int id);

        Task<bool> UpdateLeaveStatus(int id, int newStatus, string rejectReason);
      

        Task<List<Leave>> FilterLeave(int coverPersonId, DateTime beginDate, DateTime endDate);
     
      
        // In ILeaveService
        Task<int> GetLeaveCountWithStatusUnReadAsync();

    }
}
