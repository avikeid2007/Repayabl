using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Data.DTOs
{
    public partial class Property
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Society { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        public int Zip { get; set; }
        public int FloorCount { get; set; }
        public string Images { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
