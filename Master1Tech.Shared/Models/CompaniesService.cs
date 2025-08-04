using Master1Tech.Models;

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
