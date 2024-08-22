using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
  
        private readonly IAllocatedLeaveService _allocatedLeaveService;
        public EmployeeService(IEmployeeRepository employeeRepository, IAllocatedLeaveService allocatedLeaveService)
        {
            _employeeRepository = employeeRepository;
            _allocatedLeaveService = allocatedLeaveService;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var newEmployee = await _employeeRepository.CreateEmployee(employee);

            try
            {
                await _allocatedLeaveService.AllocateAnnualLeave(newEmployee);
                await _allocatedLeaveService.AllocatedCasualLeave(newEmployee);
            }
            catch (Exception ex)
            {  
                throw new InvalidOperationException("Error occurred while allocating leaves.", ex);
            }
            return newEmployee;
        }

        public async Task<string> DeleteEmployee(int id)
        {
            var res = await _employeeRepository.DeleteEmployee(id);
            return res;
        }

        public async Task<Employee?> GetEmployeeByID(int id)
        {
            var res = await _employeeRepository.GetEmployeeByID(id);
            return res;
        }

        public async Task<List<Employee>> GetEmployees(string searchTerm, int pageNumber, int pageSize)
        {
            return await _employeeRepository.GetEmployees(searchTerm, pageNumber, pageSize);
        }


        public async Task<Employee> UpdateEmployee(Employee employeeRequest)
        {
            var res = await _employeeRepository.UpdateEmployee(employeeRequest);
            return res;
        }
    }
}
