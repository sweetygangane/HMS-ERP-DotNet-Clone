using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Models
{
public class Timing
    {
        public  int Id { get; set; }
        public string? DoctorId { get; set; }
        public ApplicationUser Doctor{ get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
    }
}

namespace Hms.Models
{
    public enum Status
    {
        Availabe,Pending,Confirm
    }
}