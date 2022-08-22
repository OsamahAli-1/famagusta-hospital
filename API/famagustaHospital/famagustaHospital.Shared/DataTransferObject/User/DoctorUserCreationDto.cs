using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.DataTransferObject.User
{
    public class DoctorUserCreationDto
    {
        public DoctorUserCreationDto()
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
        public string? Department { get; set; }
        public string? Position { get; set; }
        public bool IsActive { get; set; }
    }
}
