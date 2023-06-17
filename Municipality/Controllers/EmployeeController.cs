using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Municipality.Data;
using Municipality.Entities;
using Municipality.Models;

namespace Municipality.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class EmployeeController:ControllerBase
{
    private readonly AppDbContext _db;

    public EmployeeController(AppDbContext context)
    {
        _db = context;
    }
    
    [HttpGet]
    public Employee Get(int id)
    {
        return _db.Employees.Find(id);
    }
    
    [HttpGet]
    public IEnumerable<Employee> GetAll()
    {
        return _db.Employees.ToArray();
    }

    [HttpPost]
    public IActionResult Create([FromForm]CreateEmployeeModel employeeRequest)
    {
        if (employeeRequest is null)
        {
            return BadRequest();
        }

        var employee = new Employee()
        {
            Fullname = employeeRequest.Fullname,
            Content = employeeRequest.Content,
            Position = employeeRequest.Position
        };
        
        using (var ms = new MemoryStream())
        {
            employeeRequest.Image.CopyTo(ms);

            employee.Image = ms.ToArray();
        }
    
        _db.Employees.Add(employee);
        _db.SaveChanges();

        return Ok("Added succesfully");
    }

    [HttpPut]
    public IActionResult Update([FromForm]UpdateEmployeeModel employeeRequest)
    {
        if (employeeRequest is null)
        {
            return BadRequest();
        }

        var employee = new Employee()
        {
            Id = employeeRequest.Id,
            Fullname = employeeRequest.Fullname,
            Content = employeeRequest.Content,
            Position = employeeRequest.Position
        };
        
        using (var ms = new MemoryStream())
        {
            employeeRequest.Image.CopyTo(ms);

            employee.Image = ms.ToArray();
        }
        
        _db.Update(employee);
        _db.SaveChanges();
        
        return Ok("Updated succesfully");
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var employee = _db.Employees.Find(id);
        
        if (employee is null)
        {
            return BadRequest();
        }
        _db.Remove(employee);
        _db.SaveChanges();

        return Ok("Deleted succesfully");
    }
}