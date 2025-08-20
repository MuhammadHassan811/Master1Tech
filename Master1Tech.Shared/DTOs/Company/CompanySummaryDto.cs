using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.Company
{
    public class CompanySummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? LogoUrl { get; set; }
        public string? Services { get; set; }
        public int? Rating { get; set; }
        public bool IsVerified { get; set; }
        public bool? IsTopCompany { get; set; }
        public string? Slug { get; set; }
    }
}
