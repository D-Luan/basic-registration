using BasicRegistration.App.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicRegistration.App.Data;

public class RegistrationDbContext : DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; set; } = null!;
}
