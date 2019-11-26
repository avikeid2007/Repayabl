using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Models
{
    public partial class RoomAllotment : Auditor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RoomId { get; set; }
        public Guid TenantId { get; set; }
        
        [Required]
        public DateTime? AllotmentDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.RoomAllotments))]
        public virtual Tenant Tenant { get; set; }
        
        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Models.Room.RoomAllotments))]
        public virtual Room Room { get; set; }
        
    }
}

