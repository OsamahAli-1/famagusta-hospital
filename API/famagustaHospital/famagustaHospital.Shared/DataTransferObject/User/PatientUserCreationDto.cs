using System.ComponentModel.DataAnnotations;

namespace famagustaHospital.Shared.DataTransferObject;

public record PatientUserCreationDto
{
    public PatientUserCreationDto()
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
    public string? MedicalNumber { get; set; }
    public string? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public float? Length { get; set; }
    public float? Weight { get; set; }
    public bool IsActive { get; set; }
}

