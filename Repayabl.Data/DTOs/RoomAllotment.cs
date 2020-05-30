using System;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Data.DTOs
{
    public partial class RoomAllotment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RoomId { get; set; }
        public Guid TenantId { get; set; }

        [Required]
        public DateTime? AllotmentDate { get; set; }
        public DateTime? ReleaseDate { get; set; }


        public Tenant Tenant { get; set; }


        public Room Room { get; set; }

    }
}

