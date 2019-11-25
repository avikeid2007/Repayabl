using System;
using System.ComponentModel.DataAnnotations;

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
