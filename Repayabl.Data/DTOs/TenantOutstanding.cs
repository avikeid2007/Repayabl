using System;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Data.DTOs
{
    public partial class TenantOutstanding
    {
        [Key]
        public Guid Id { get; set; }

        //[Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalAdvance { get; set; }
        //[Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }


        public virtual Tenant Tenant { get; set; }
    }
}
