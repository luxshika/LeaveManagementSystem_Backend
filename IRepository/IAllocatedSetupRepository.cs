using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IAllocatedSetupRepository
    {
        Task<AllocatedSetup> CreateAllocatedSetup(AllocatedSetup allocatedSetup);
        Task<List<AllocatedSetup>> GetAllocatedSetups();
        Task<List<AllocatedSetup>> GetAllocatedSetupByID(int id);
        Task<AllocatedSetup> UpdateAllocatedSetup(AllocatedSetup allocatedSetupRequest);
        Task<string> DeleteAllocatedSetup(int id);
    }
}
