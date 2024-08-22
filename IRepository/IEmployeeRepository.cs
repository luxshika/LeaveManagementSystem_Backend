﻿using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        //Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployees(string searchTerm, int pageNumber, int pageSize);
        Task<Employee?> GetEmployeeByID(int id);
        Task<Employee> UpdateEmployee(Employee employeeRequest);
        Task<string> DeleteEmployee(int id);
    }
}