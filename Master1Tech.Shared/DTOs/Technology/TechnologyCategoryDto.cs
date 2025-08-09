using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.Technology
{
    public class TechnologyCategoryDto
    {
        public string Category { get; set; } = string.Empty;
        public List<TechnologySummaryDto> Technologies { get; set; } = new();
        public int Count { get; set; }
    }
}
