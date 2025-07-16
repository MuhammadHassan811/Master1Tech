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
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [StringLength(100)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string ProjectURL { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
