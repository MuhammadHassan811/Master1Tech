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
    public class CompanyLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; } = "Pakistan";

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public bool IsHeadquarters { get; set; } = false;
    }
}
