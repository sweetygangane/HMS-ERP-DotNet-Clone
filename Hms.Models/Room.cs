using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int HospitalId { get; set; }

        [ForeignKey("HospitalId")]
        public HospitalInfo Hospital { get; set; }
    }
}