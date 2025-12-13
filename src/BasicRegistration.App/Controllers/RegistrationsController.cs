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
}
