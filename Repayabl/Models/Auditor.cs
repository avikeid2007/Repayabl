using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repayabl.Models
{
    public abstract class Auditor
    {
        [Required]
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modifed { get; set; }
        public string ModifiedBy { get; set; }
    }
}
