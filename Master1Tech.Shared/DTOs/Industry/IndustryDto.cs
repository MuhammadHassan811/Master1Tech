using System.ComponentModel.DataAnnotations;

namespace Master1Tech.Shared.DTOs.Industry
{
    public class IndustryDto
    {
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public string? Name { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public string? Description { get; set; }
    }
}
