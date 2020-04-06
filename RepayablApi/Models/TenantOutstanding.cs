using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class TenantOutstanding : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalAdvance { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? TotalPending { get; set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.TenantOutstandings))]
        public virtual Tenant Tenant { get; set; }
    }
}
