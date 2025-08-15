using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.GetInTouch
{
    public class GetInTouchCreateDto
    {
        public string? FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNo { get; set; } = string.Empty;

        public string? CompanyName { get; set; } = string.Empty;

        public string? JobTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Service is required")]
        public int Service { get; set; }

        [MaxWords(1000, ErrorMessage = "Project description cannot exceed 1000 words")]
        public string? ProjectDescription { get; set; } = string.Empty;

        public bool GetVettedCompanies { get; set; } = true;

        public IFormFile? AttachmentFile { get; set; }

        public string? CompanyId { get; set; }
    }
}
