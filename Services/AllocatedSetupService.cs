using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.Services
{
    public class AllocatedSetupService:IAllocatedSetupService
    {
        private readonly IAllocatedSetupRepository _allocatedServiceRepository;
        public AllocatedSetupService(IAllocatedSetupRepository allocatedServiceRepository)
        {
            _allocatedServiceRepository = allocatedServiceRepository;
        }
        public async Task<AllocatedSetup> CreateAllocatedSetup(AllocatedSetup allocatedSetup)
        {

            return await _allocatedServiceRepository.CreateAllocatedSetup(allocatedSetup);
        }

        public async Task<string> DeleteAllocatedSetup(int id)
        {
            var res = await _allocatedServiceRepository.DeleteAllocatedSetup(id);
            return res;
        }

        public async Task<List<AllocatedSetup>> GetAllocatedSetupByID(int id)
        {
            var res = await _allocatedServiceRepository.GetAllocatedSetupByID(id);
            return res;
        }

        public async Task<List<AllocatedSetup>> GetAllocatedSetups()
        {
            var res = await _allocatedServiceRepository.GetAllocatedSetups();
            return res;
        }



        public async Task<AllocatedSetup> UpdateAllocatedSetup(AllocatedSetup allocatedSetupRequest)
        {
            var res = await _allocatedServiceRepository.UpdateAllocatedSetup(allocatedSetupRequest);
            return res;
        }

    }
}
