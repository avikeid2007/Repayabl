using System;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Data.DTOs
{
    public partial class TenantDocument
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

        public Tenant Tenant { get; set; }
    }
}
