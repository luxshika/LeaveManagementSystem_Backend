using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LeaveManagementSystem_Backend.DBContext;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem_Backend.Utilities;


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
        public async Task<ActionResult> CreateEmployee(EmployeeRequest employeeRequest)
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

        [HttpPut("{id}")] 
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employeeRequest)
        {

            if (id != employeeRequest.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }

         
            var res = await _employeeService.UpdateEmployee(employeeRequest);

            if (res == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(res);
        }


        [HttpGet("delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var res = await _employeeService.DeleteEmployee(id);

            //return Accepted(new { message = "Hello world" });
            return Ok(new { message = res });

        }
       
    }
}
