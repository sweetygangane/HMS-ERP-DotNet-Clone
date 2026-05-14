using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Hms.Models
{
    public class Appointement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
        public ICollection<Appointement> Appointements { get; set; }
        

    }
}