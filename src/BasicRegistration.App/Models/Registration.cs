using System.Security.Principal;

namespace BasicRegistration.App.Models;

public class Registration
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
}
