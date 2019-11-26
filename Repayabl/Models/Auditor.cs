using System;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Models
{
    public abstract class Auditor
    {
        [Required]
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }   
}
