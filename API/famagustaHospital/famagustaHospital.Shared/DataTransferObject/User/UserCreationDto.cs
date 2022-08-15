using System.ComponentModel.DataAnnotations;

namespace famagustaHospital.Shared.DataTransferObject;

public record UserCreationDto
{
    public UserCreationDto()
    {
        IsActive = true;
    }

    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Phone]
    public string? Mobile { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Role { get; set; }
    public bool IsActive { get; set; }
}

