using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class PatientUser
    {
        [Required]
        public Guid Id { get; set; }
        public string? MedicalNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public float? Length { get; set; }
        public float? Weight { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Chronic> Chronics { get; set; }
        public string systemUserId { get; set; }
        public SystemUser systemUser { get; set; }
    }
}
