using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class TenantOutstandings : Auditor
    {
        public Guid Id { get; set; }
        public decimal? TotalAdvance { get; set; }
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }

        public virtual Tenants Tenant { get; set; }
    }
}
