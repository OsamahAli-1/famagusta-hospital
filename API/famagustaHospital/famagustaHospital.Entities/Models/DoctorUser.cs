using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class DoctorUser
    {
        [Required]
        public Guid Id { get; set; }
        public string? StaffNumber { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<DoctorAvailablability> doctorAvailablabilities { get; set; }
        public ICollection<Qualification> qualifications{ get; set; }
        public ICollection<Experience> experiences{ get; set; }
        public string systemUserId { get; set; }
        public SystemUser systemUser { get; set; }

    }
}
