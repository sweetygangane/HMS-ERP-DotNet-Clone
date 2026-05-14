using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Models
{
    public class PatientReport
    {
        public int Id { get; set; }

        public string Diagnose { get; set; }

        public string Medicine { get; set; }

        public string DoctorId { get; set; }

        public ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }

        public ApplicationUser Patient { get; set; }

        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}