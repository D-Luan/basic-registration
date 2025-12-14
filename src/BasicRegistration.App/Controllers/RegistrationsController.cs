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

    [HttpGet("date")]
    public IActionResult GetRegistrationByDate(DateTime date)
    {
        var registrations = _dbContext.Registrations
            .Where(x => x.RegistrationDate.Date == date.Date)
            .ToList();

        if (!registrations.Any())
        {
            return NotFound();
        }

        return Ok(registrations);
    }

    [HttpGet("birth-month")]
    public IActionResult GetRegistrationByBirthDate(int month)
    {
        var registrations = _dbContext.Registrations
            .Where(x => x.BirthDate.Month == month)
            .ToList();

        if (!registrations.Any())
        {
            return NotFound();
        }

        return Ok(registrations);
    }

    [HttpGet("date-month")]
    public IActionResult GetRegistrationByMonth(int month)
    {
        if (month < 1 || month > 12)
        {
            return BadRequest();
        }

        var registrations = _dbContext.Registrations
            .Where(x => x.RegistrationDate.Month == month)
            .ToList();

        if (!registrations.Any())
        {
            return NotFound();
        }

        return Ok(registrations);
    }

    [HttpGet("date-year")]
    public IActionResult GetRegistrationByYear(int year)
    {
        if (year < 2025)
        {
            return BadRequest();
        }

        if (year > DateTime.UtcNow.Year)
        {
            return BadRequest();
        }

        var registrations = _dbContext.Registrations
            .Where(x => x.RegistrationDate.Year == year)
            .ToList();

        if (!registrations.Any())
        {
            return NotFound();
        }

        return Ok(registrations);
    }

    [HttpGet("hour")]
    public IActionResult GetRegistrationByTime(int hour)
    {
        var registrations = _dbContext.Registrations
            .Where(x => x.RegistrationDate.Hour == hour)
            .ToList();

        if (!registrations.Any())
        {
            return NotFound();
        }

        return Ok(registrations);
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
