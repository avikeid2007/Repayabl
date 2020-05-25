using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class TenantDocument : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public byte[] Payload { get; set; }
        [Required]
        [StringLength(50)]
        public string MimeType { get; set; }
        [Required]
        [StringLength(50)]
        public string FileExtension { get; set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.TenantDocuments))]
        public virtual Tenant Tenant { get; set; }
    }
}
