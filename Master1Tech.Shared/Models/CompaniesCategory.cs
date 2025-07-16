using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class CompaniesCategory
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
