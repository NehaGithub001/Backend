using Backend.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetDepartment()
        {

           var depatments=await _departmentService.GetDepartments();

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
            var depatment = await _departmentService.GetDepartmentById(id);
            if (depatment == null)
            {
                return NotFound();
            }
            return Ok(depatment);
        }
       
    }
}
