using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;


namespace Repayabl.Models
{
    public partial class TenantOutstanding : Auditor
    {
        public Guid Id { get; set; }
        public decimal? TotalAdvance { get; set; }
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
