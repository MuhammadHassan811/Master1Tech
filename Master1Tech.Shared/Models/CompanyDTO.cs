using System.ComponentModel.DataAnnotations;

namespace Master1Tech.Models
{
    public class CompanyDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? LogoUrl { get; set; } = string.Empty;
        
        public string TeamSize { get; set; } = string.Empty;

        public string Headquarter { get; set; }
        
        public string HourlyRate { get; set; } = string.Empty;
 
        public int? Rating { get; set; } = 0;
        public bool IsVerified { get; set; }
        public bool? IsTopCompany { get; set; }

        public string? LogoText { get; set; }
        public string? LogoColor { get; set; }
        public string? EmployeesCount { get; set; }
        public string? FoundedYear { get; set; }

        public string? WebsiteURL { get; set; }

        public string? Services { get; set; } = string.Empty;
    }
}
