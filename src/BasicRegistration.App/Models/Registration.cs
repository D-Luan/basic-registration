using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BasicRegistration.App.Models;

public class Registration
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of birth is required")]
    public DateOnly BirthDate { get; set; }

    [Required(ErrorMessage = "State is required")]
    [StringLength(20)]
    public string State { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; }
}
