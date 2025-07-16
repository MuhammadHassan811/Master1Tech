using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        public string Bio { get; set; }

        [StringLength(255)]
        public string PhotoURL { get; set; }

        [StringLength(255)]
        public string LinkedInURL { get; set; }

        public bool IsFounder { get; set; } = false;
    }
}
