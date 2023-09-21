using EmsEmployeeManagementSytem.Data;
using EmsEmployeeManagementSytem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmsEmployeeManagementSytem.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _dataContext.employees.ToListAsync();
            return Ok(employees);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _dataContext.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _dataContext.employees.Add(employee);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _dataContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employee.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _dataContext.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _dataContext.employees.Remove(employee);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/employees/search?query=
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees([FromQuery] string query)
        {
            // Check if the query can be parsed as an integer
            if (int.TryParse(query, out int employeeId))
            {
                // If it's an integer, search by employee ID
                var employee = await _dataContext.employees.FindAsync(employeeId);
                if (employee != null)
                {
                    return Ok(new List<Employee> { employee });
                }
            }
            else
            {
                // If it's not an integer, search by name
                var employees = await _dataContext.employees
                    .Where(e => e.Name.Contains(query))
                    .ToListAsync();

                return Ok(employees);
            }

            // If no matching employee was found, return Not Found
            return NotFound();
        }











    }
}
