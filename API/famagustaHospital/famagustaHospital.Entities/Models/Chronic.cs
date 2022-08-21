using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class Chronic
    {
        public Guid Id { get; set; }
        public string DiseaseName { get; set; }
        public DateTime DiagnosedOn { get; set; }
    }
}
