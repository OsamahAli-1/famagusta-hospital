using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class Qualification
    {
        public Guid Id { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string QualificationName { get; set; }
    }
}
