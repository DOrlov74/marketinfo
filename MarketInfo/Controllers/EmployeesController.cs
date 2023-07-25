using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketInfo.Data;
using MarketInfo.Model;

namespace MarketInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public EmployeesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Employees/5
        [HttpGet("{companyId}", Name = "GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(long companyId)
        {
          var companyEmployees = await _context.Employees.Where(e => e.CompanyId == companyId).ToListAsync();
          if (companyEmployees.Count == 0)
          {
            return NotFound();
          }
          return companyEmployees;
        }

        // GET: api/Employees/5/5
        [HttpGet("{companyId}/{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployee(long companyId, long id)
        {
          var companyEmployees = await _context.Employees.Where(e => e.CompanyId == companyId).ToListAsync();
          if (companyEmployees.Count == 0)
          {
            return NotFound();
          }
          var employee = companyEmployees.FirstOrDefault(o => o.Id == id);

          if (employee == null)
          {
            return NotFound();
          }

          return employee;
        }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}", Name = "PutEmployee")]
    public async Task<IActionResult> PutEmployee(long id, Employee employee)
    {
      if (id != employee.Id)
      {
        return BadRequest();
      }

      _context.Entry(employee).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EmployeeExists(id))
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

    // POST: api/Employees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Company>> PostEmployee(Employee employee)
    {
      if (_context.Employees == null)
      {
        return Problem("Entity set 'CompanyContext.Employees'  is null.");
      }
      _context.Employees.Add(employee);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetEmployee), new { companyId = employee.CompanyId, id = employee.Id }, employee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(long id)
    {
      if (_context.Employees == null)
      {
        return NotFound();
      }
      var employee = await _context.Employees.FindAsync(id);
      if (employee == null)
      {
        return NotFound();
      }

      _context.Employees.Remove(employee);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool EmployeeExists(long id)
    {
      return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
