using Microsoft.AspNetCore.Mvc;
using ShiwanshApi.Models;
using ShiwanshApi.Repositories;

namespace ShiwanshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(_employee.GetAllEmployee());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok(_employee.AddEmployee(employee));
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            return Ok(_employee.UpdateEmployee(employee));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            var result = _employee.DeleteEmployeeById(id);
            if (!result) return NotFound();
            return Ok("Data deleted successfully!");
        }
    }
}
