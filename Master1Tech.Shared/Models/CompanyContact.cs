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
    public class CompanyContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactType { get; set; } // 'Email', 'Phone', 'Social', etc.

        [Required]
        [StringLength(100)]
        public string ContactValue { get; set; }

        public bool IsPrimary { get; set; } = false;
    }
}
