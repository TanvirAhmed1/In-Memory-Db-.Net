using InMemoryDb.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InMemoryDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        [HttpGet("{id}")]
        public Employee GetEmpolyeeById(int id)
        {
            return _context.Employees.SingleOrDefault(p => p.Id == id);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.SingleOrDefault(p => p.Id == id);
            if(emp == null)
            {
                return NotFound("Employee with ID " + id + "not found");
            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return Ok("Employee with ID " + id + " deleted successfully.");
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Created("api/employees/ " + employee.Id, employee);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(p => p.Id == id);
            if (emp == null)
            {
                return NotFound("Employee with ID " + id + "not found");
            }
            if(emp.Name != null)
            {
                emp.Name = employee.Name;
            }
            if(emp.Gender != null)
            {
                emp.Gender = employee.Gender;
            }
            if(emp.Age != 0)
            {
                emp.Age = employee.Age;
            }
            if(emp.Salary != 0)
            {
                emp.Salary = employee.Salary;
            }
            _context.Update(emp);
            _context.SaveChanges();
            return Ok("Employee with Id " + id + "updated successfully.");
        }
    }
}
