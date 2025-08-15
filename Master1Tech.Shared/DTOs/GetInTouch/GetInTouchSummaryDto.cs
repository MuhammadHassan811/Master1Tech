using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.GetInTouch
{
    public class GetInTouchSummaryDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? CompanyName { get; set; } = string.Empty;
        public int Service { get; set; }
        public bool Status { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
