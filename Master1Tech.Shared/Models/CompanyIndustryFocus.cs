using Master1Tech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master1Tech.Shared.Models
{
    public class CompanyIndustryFocus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FocusPercentage { get; set; } = string.Empty;
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public int IndustryID { get; set; }
        public Industry Industry { get; set; }



    }
}
