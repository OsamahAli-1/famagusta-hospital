using System.ComponentModel.DataAnnotations;

namespace famagustaHospital.Shared.DataTransferObject;

public record UserUpdateDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}

