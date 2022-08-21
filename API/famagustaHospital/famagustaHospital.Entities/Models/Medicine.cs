using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Models
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string MedicineName { get; set; }
        public string Instruction { get; set; }
    }
}
