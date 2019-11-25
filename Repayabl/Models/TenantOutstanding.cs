using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Models
{
    public partial class TenantOutstanding : Auditor
    {
        [Key]
        public Guid Id { get; set; }
      
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalAdvance { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.TenantOutstandings))]
        public virtual Tenant Tenant { get; set; }
    }
}
