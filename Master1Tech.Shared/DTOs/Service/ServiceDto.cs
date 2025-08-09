using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.Service
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }

        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Optional: Include related companies count if needed
        public int CompanyCount { get; set; }
    }
}
