using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Hms.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
    public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
        public string  PictureUrl { get; set; }
        public Department Department { get; set; }
        [NotMapped]
        public ICollection<Appointement> Appointments { get; set; }
        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }

        public ICollection<PatientReport> PatientReport { get; set; }
        public DbSet<HospitalInfo> Hospitals { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public string? City { get; set; }
    }
}

namespace Hms.Models
{
    public enum Gender
    {
        Male,Female,Other
    }
}