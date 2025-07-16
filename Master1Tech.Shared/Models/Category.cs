using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        // Navigation properties
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
        public ICollection<CompaniesCategory> CompanyCategories { get; set; }
    }
}
