using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master1Tech.Shared.Models
{
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnologyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Category { get; set; } // 'Programming Language', 'Framework', 'Tool', etc.

        // Navigation properties
        public ICollection<CompanyTechnology> CompanyTechnologies { get; set; }
    }
}
