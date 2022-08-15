namespace famagustaHospital.Shared.DataTransferObject;

public record UserViewDto 
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public bool IsActive { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }

}

