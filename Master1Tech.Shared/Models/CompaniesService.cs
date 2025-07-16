using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class CompaniesService
    {
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public int ServiceID { get; set; }
        public Service Service { get; set; }
    }
}
