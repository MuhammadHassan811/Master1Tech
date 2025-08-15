using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.GetInTouch
{
    public class GetInTouchStatusUpdateDto
    {
        [Required]
        public int Id { get; set; }

        public bool Status { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
