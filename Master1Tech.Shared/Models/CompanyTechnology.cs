using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class CompanyTechnology
    {
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public int TechnologyID { get; set; }
        public Technology Technology { get; set; }

        [StringLength(20)]
        public string ProficiencyLevel { get; set; } // 'Beginner', 'Intermediate', 'Expert'
    }
}
