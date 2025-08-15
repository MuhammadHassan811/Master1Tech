using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class GetInTouch
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is required")]
        public string PhoneNo { get; set; } = string.Empty;
        public string? CompanyName { get; set; } = string.Empty;
        public string? JobTitle { get; set; } = string.Empty;
        public int Service { get; set; }
        [MaxWords(1000, ErrorMessage = "Company description cannot exceed 1000 words")]
        public string? ProjectDescription { get; set; } = string.Empty;
        public bool GetVettedCompanies { get; set; } = true;
        public string? FilePath { get; set; } = string.Empty;
        public string? FileName { get; set; } = string.Empty;
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
        public bool Status { get; set; } = false;
        public DateTime? DateAdded { get; set; } = DateTime.MinValue;
        public DateTime? DateUpdated { get; set; }= DateTime.MinValue;
        public bool IsCompleted { get; set; }= false;
    }

    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordsAttribute(int maxWords)
        {
            _maxWords = maxWords;
            ErrorMessage = $"The field cannot exceed {_maxWords} words.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var wordCount = value.ToString()
                .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Length;

            if (wordCount > _maxWords)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}
