using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private SqlPracticeContext _context { get; }

        public EmployeeController(SqlPracticeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetEmployees([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            if (page < 1 || size < 1)
            {
                return BadRequest("Page and size must be greater than 0.");
            }

            var totalItems = await _context.Employees.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)size);

            if (page > totalPages && totalPages > 0)
            {
                return BadRequest("Page number exceeds total pages.");
            }

            var employees = await _context.Employees
                .OrderByDescending(q => q.EmpName)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

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
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
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
            await _context.Employees.AddAsync(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]

        public async Task<ActionResult<Employee>> EditEmployee(int id, [FromBody] Employee dto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
            if (employee != null)
            {
                employee.Email = dto.Email;
                employee.City = dto.City;
                employee.Status = dto.Status;
                employee.EmpName = dto.EmpName;
                employee.Age = dto.Age;
                employee.Mobile = dto.Mobile;
                employee.DeptId=dto.DeptId;
                _context.Employees.Update(employee);
            }
            await _context.SaveChangesAsync();
            return Ok(dto);

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(q => q.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;

        }
    }
}
