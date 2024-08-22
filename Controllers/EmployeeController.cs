using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LeaveManagementSystem_Backend.DBContext;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employeeRequest)
        {
            var res = await _employeeService.CreateEmployee(employeeRequest);
            return Ok(res);
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees(string searchTerm = "", int pageNumber = 1, int pageSize = 10)
        {
            var employees = await _employeeService.GetEmployees(searchTerm, pageNumber, pageSize);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeByID(int id)
        {
            var res = await _employeeService.GetEmployeeByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employeeRequest)
        {
            var res = await _employeeService.UpdateEmployee(employeeRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var res = await _employeeService.DeleteEmployee(id);
            return Ok(res);

        }
       
    }
}
