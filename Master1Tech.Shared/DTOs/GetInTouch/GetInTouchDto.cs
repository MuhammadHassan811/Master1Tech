using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.GetInTouch
{
    public class GetInTouchDto
    {
        public int Id { get; set; }

        public string? FullName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        public string PhoneNo { get; set; } = string.Empty;

        public string? CompanyName { get; set; } = string.Empty;

        public string? JobTitle { get; set; } = string.Empty;

        public int Service { get; set; }

        public string? ProjectDescription { get; set; } = string.Empty;

        public bool GetVettedCompanies { get; set; } = true;

        public string? FilePath { get; set; } = string.Empty;
        public string? FileName { get; set; } = string.Empty;

        public string? CompanyId { get; set; }

        // Navigation property info
        public string? CompanyDisplayName { get; set; }

        public bool Status { get; set; } = false;

        public DateTime? DateAdded { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
