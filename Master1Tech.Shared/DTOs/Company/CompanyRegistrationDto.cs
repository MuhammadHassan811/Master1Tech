using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.Company
{
    public class CompanyRegistrationDto
    {
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a primary service")]
        public string PrimaryService { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid website URL")]
        public string? Website { get; set; }

        [Required(ErrorMessage = "Please select if you want to be featured")]
        public string FeatureOnSite { get; set; } = "Yes";

        public string? Comments { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; } = "Pakistan";
        public string? TeamSize { get; set; }
        public string? FoundedYear { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    }
}
