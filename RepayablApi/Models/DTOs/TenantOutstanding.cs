using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models.DTOs
{
    public class TenantOutstanding
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalAdvance { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalPending { get; set; }
        public int TenantId { get; set; }
    }
}