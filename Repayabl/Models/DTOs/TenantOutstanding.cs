using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Models.DTOs
{
    public class TenantOutstanding
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalAdvance { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalPending { get; set; }
        public Guid TenantId { get; set; }
    }
}