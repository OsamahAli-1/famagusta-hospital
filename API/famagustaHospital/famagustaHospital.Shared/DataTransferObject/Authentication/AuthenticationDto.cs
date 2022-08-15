using System.ComponentModel.DataAnnotations;

namespace famagustaHospital.Shared.DataTransferObject;

public record AuthenticationDto
{
    [Required(ErrorMessage = "UserName is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}

