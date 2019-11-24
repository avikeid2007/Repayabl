using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class TenantDocuments : Auditor
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public byte[] Payload { get; set; }
        public string MimeType { get; set; }
        public string FileExtension { get; set; }
        public Guid TenantId { get; set; }

        public virtual Tenants Tenant { get; set; }
    }
}
