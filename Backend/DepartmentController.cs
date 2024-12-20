using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private SqlPracticeContext _context { get; }

        public DepartmentController(SqlPracticeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetDepartment()
        {

            var depatments = await _context.Depatments
                .OrderByDescending(q => q.DeptName)
                .ToListAsync();

            var response = new
            {
                data = depatments
            };

            return Ok(response);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var depatment = await _context.Depatments.FirstOrDefaultAsync(q => q.DeptId == id);
            if (depatment == null)
            {
                return NotFound();
            }
            return Ok(depatment);
        }
       
    }
}
