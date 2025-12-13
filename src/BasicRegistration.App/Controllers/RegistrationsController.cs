using BasicRegistration.App.Data;
using BasicRegistration.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicRegistration.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly RegistrationDbContext _dbContext;

    public RegistrationsController(RegistrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult CreateRegistration(Registration registration)
    {
        _dbContext.Registrations.Add(registration);
        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllRegistrations()
    {
        var registrations = _dbContext.Registrations.ToList();
        return Ok(registrations);
    }

    [HttpGet("{id}")]
    public IActionResult GetRegistrationById(int id)
    {
        var registration = _dbContext.Registrations.Find(id);

        if (registration == null)
        {
            return NotFound();
        }

        return Ok(registration);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRegistration(int id, Registration registration)
    {
        var newRegistration = _dbContext.Registrations.Find(id);

        if (newRegistration == null)
        {
            return NotFound();
        }

        newRegistration.Name = registration.Name;
        newRegistration.BirthDate = registration.BirthDate;
        newRegistration.State = registration.State;
        newRegistration.RegistrationDate = registration.RegistrationDate;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRegistration(int id)
    {
        var registration = _dbContext.Registrations.Find(id);

        if (registration == null)
        {
            return NotFound();
        }

        _dbContext.Registrations.Remove(registration);
        _dbContext.SaveChanges();

        return NoContent();
    }
}
