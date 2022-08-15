using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models;

public class SystemUser:IdentityUser
{
    [Required]
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? Mobile { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

}
