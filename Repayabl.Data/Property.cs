﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Data
{
    public partial class Property : Auditor
    {
        public Property()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public int Zip { get; set; }
        public int FloorCount { get; set; }
        [Required]
        [StringLength(50)]
        public string Remarks { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Data.User.Properties))]
        public virtual User User { get; set; }
        [InverseProperty("Property")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
