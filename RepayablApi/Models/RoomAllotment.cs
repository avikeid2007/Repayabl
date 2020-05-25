using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class RoomAllotment : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }
        public int TenantId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? AllotmentDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.RoomAllotments))]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Models.Room.RoomAllotments))]
        public virtual Room Room { get; set; }

    }
}

