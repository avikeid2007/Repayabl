using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repayabl.Models
{
    public abstract class Auditor
    {
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modifed { get; set; }
        public string ModifiedBy { get; set; }
    }
}
