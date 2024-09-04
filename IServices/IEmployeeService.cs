using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(EmployeeRequest employee);
        //Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployees(string searchTerm, int pageNumber, int pageSize);
        Task<Employee?> GetEmployeeByID(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<string> DeleteEmployee(int id);
    }
}
