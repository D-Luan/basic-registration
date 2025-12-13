using BasicRegistration.App.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicRegistration.App.Data;

public class RegistrationDbContext : DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
        : base(options)
    {
    }

    DbSet<Registration> Registrations { get; set; } = null!;
}
