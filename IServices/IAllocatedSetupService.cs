using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IAllocatedSetupService
    {
        Task<AllocatedSetup> CreateAllocatedSetup(AllocatedSetup allocatedSetup);
        Task<List<AllocatedSetup>> GetAllocatedSetups();
        Task<List<AllocatedSetup>> GetAllocatedSetupByID(int id);
        Task<AllocatedSetup> UpdateAllocatedSetup(AllocatedSetup allocatedSetup);
        Task<string> DeleteAllocatedSetup(int id);
    }
}
