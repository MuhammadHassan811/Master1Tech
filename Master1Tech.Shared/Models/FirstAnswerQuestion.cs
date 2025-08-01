using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master1Tech.Models;

namespace Master1Tech.Shared.Models
{
    public class FirstAnswerQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(2000)]
        public string? Question { get; set; }

        [StringLength(2000)]
        public string? Answer { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
