using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hms.Models
{
    public class HospitalInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Country { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}