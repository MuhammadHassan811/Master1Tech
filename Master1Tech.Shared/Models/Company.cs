using Master1Tech.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master1Tech.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? FoundedYear { get; set; }

        public int? EmployeesCount { get; set; }

        [StringLength(100)]
        public string Headquarters { get; set; }

        [StringLength(255)]
        public string WebsiteURL { get; set; }

        [StringLength(255)]
        public string LogoURL { get; set; }

        public bool IsVerified { get; set; } = false;

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<CompaniesCategory> CompanyCategories { get; set; }
        public ICollection<CompaniesService> CompanyServices { get; set; } = new List<CompaniesService>();
        public ICollection<CompanyLocation> Locations { get; set; } = new List<CompanyLocation>();
        public ICollection<CompanyContact> Contacts { get; set; } = new List<CompanyContact>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<CompanyTechnology> Technologies { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }

        //public int Id { get; set; }
        //public string Name { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;
        //public string Location { get; set; } = string.Empty;
        //public string Country { get; set; } = string.Empty;
        //public string LogoUrl { get; set; } = string.Empty;
        //public string TeamSize { get; set; } = string.Empty;
        //public string HourlyRate { get; set; } = string.Empty;
        //public List<string> Services { get; set; } = new();
        //public int Rating { get; set; } = 0;
        //public bool IsVerified { get; set; }
        //public bool IsTopCompany { get; set; }
        //public DateTime LastUpdated { get; set; }
    }
}
