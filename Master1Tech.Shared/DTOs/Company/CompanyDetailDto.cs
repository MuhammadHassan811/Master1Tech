using Master1Tech.Shared.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.Company
{
    public class CompanyDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? LogoUrl { get; set; }
        public string TeamSize { get; set; } = string.Empty;
        public string Headquarter { get; set; } = string.Empty;
        public string HourlyRate { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public bool IsVerified { get; set; }
        public bool? IsTopCompany { get; set; }
        public string? WebsiteURL { get; set; }
        public string? Services { get; set; }
        public string? FoundedYear { get; set; }
        public List<ServiceDto> ServicesList { get; set; } = new();
        //public List<ProjectDto> RecentProjects { get; set; } = new();
        //public ContactInfoDto ContactInfo { get; set; } = new();
    }
}
