using Backend.Data.Models;
using Backend.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetEmployees([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            if (page < 1 || size < 1)
            {
                return BadRequest("Page and size must be greater than 0.");
            }
            var employees = await _employeeService.GetEmployees(page, size);
            var totalItems = employees.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)size);

            if (page > totalPages && totalPages > 0)
            {
                return BadRequest("Page number exceeds total pages.");
            }

            var response = new
            {
                data = employees,
                totalItems = totalItems,
                totalPages = totalPages,
                currentPage = page,
                pageSize = size
            };

            return Ok(response);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // Return 404 if the employee is not found
            }
            return Ok(employee); // Return 200 with the employee data
        }

        // POST api/<EmployeeController>
        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee dto)
        {
           var employee = await _employeeService.CreateEmployee(dto);
            return Ok(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult<Employee>> EditEmployee(int id, [FromBody] Employee dto)
        {
            var employee = await _employeeService.EditEmployee(id,dto);
            return Ok(employee);

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _employeeService.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
    }
}
