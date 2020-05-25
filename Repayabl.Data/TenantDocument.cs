using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Data
{
    public partial class TenantDocument : Auditor
    {
        [Key]
        public Guid Id { get; set; }

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
        public Guid TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Data.Tenant.TenantDocuments))]
        public virtual Tenant Tenant { get; set; }
    }
}
