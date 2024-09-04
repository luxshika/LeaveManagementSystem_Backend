using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Utilities;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Employee> CreateEmployee(EmployeeRequest employeeRequest)
        {
            var newEmployee = new Employee
            {
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                Email = employeeRequest.Email,
                JoinDate = employeeRequest.JoinDate,
                EmployeeNumber = employeeRequest.EmployeeNumber,
                NicNo = employeeRequest.NicNo,
                Dob = employeeRequest.Dob,
                Nationality = employeeRequest.Nationality,
                MaritalStatus = employeeRequest.MaritalStatus,
                PositionId = employeeRequest.PositionId,
                TelephoneNumber = employeeRequest.TelephoneNumber,
                MobileNumber = employeeRequest.MobileNumber,
                PermanentAddress = employeeRequest.PermanentAddress,
                CurrentAddress = employeeRequest.CurrentAddress,
                EmergencyContactName = employeeRequest.EmergencyContactName,
                EmergencyContactNumber = employeeRequest.EmergencyContactNumber,
                EmergencyContactRelationship = employeeRequest.EmergencyContactRelationship,
                BankName = employeeRequest.BankName,
                AccountNo = employeeRequest.AccountNo,
                AccountHolder = employeeRequest.AccountHolder,
                Branch = employeeRequest.Branch,
                TypeOfAccount = employeeRequest.TypeOfAccount,
                Profile = employeeRequest.Profile,
                ConfirmDate = employeeRequest.ConfirmDate,
                //Status = employeeRequest.Status,
                
            };

            var createdEmployee = await _employeeRepository.CreateEmployee(newEmployee);

            try
            {
                await _allocatedLeaveService.AllocateAnnualLeave(createdEmployee);
                await _allocatedLeaveService.AllocatedCasualLeave(createdEmployee);

                if (employeeRequest.CreateUser)
                {
                 
                    var autoPassword = PasswordUtility.GenerateAutoPassword();
                    var user = new User
                    {
                        EmployeeId = createdEmployee.Id,
                        Email = createdEmployee.Email,
                        PasswordHash = PasswordUtility.HashPassword(autoPassword)
                    };
                    await _employeeRepository.CreateUser(user);
                    
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while processing employee creation.", ex);
            }

            return createdEmployee;
        }


        public async Task<string> DeleteEmployee(int id)
        {
            if(id == null)
            {
                return "Requested ID not available ";
            }
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
