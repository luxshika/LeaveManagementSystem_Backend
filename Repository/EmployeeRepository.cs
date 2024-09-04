using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class EmployeeRepository :IEmployeeRepository

    {
        private readonly LMSDbContext _context;
        public EmployeeRepository(LMSDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            try
            {
                var res = _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {

                throw ;
            }

        }
        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (employee == null)
            {
                return "Requested ID not available ";
            }
            //_context.Employees.Remove(employee);

            employee.isActive = false;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
           
            return " suceeded";


        }

        public Task<Employee?> GetEmployeeByID(int id)
        {
            try
            {
                var res = _context.Employees.Where(x => x.Id == id).FirstOrDefault();

                return Task.FromResult(res);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Employee>> GetEmployees(string searchTerm, int pageNumber, int pageSize)
        {
            //var query = _context.Employees.AsQueryable();
            var query = _context.Employees
        .Where(e => e.isActive) 
        .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(e => e.FirstName.Contains(searchTerm) || e.Email.Contains(searchTerm) || e.LastName.Contains(searchTerm)||
                                          e.NicNo.Contains(searchTerm) || e.CurrentAddress.Contains(searchTerm)||e.MaritalStatus.Contains(searchTerm)
                                          ||e.PermanentAddress.Contains(searchTerm)||e.BankName.Contains(searchTerm)||e.TelephoneNumber.Contains(searchTerm)||
                                          e.AccountHolder.Contains(searchTerm)||e.AccountNo.Contains(searchTerm));
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<Employee> UpdateEmployee(Employee employeeRequest)
        {
            try
            {
                var res = _context.Employees.Update(employeeRequest);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
