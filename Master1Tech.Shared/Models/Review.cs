using Master1Tech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [StringLength(100)]
        public string ReviewerName { get; set; }

        [StringLength(100)]
        public string ReviewerEmail { get; set; }

        [Required]
        [Column(TypeName = "decimal(2,1)")]
        [Range(1, 5)]
        public decimal Rating { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;
    }
}
