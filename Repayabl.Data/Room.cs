using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repayabl.Data
{
    public partial class Room : Auditor
    {
        public Room()
        {
            RentTransactions = new HashSet<RentTransaction>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        public int? RoomFloorNo { get; set; }
        public Guid PropertyId { get; set; }
        public Guid? CurrentTenantId { get; set; }
        //[Column(TypeName = "numeric(15, 2)")]
        public decimal MonthlyRent { get; set; }
        //[Column(TypeName = "numeric(10, 2)")]
        public decimal ElectRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastBillPaidDate { get; set; }
        public Guid? LastPaidBillId { get; set; }

        [ForeignKey(nameof(CurrentTenantId))]
        [InverseProperty(nameof(Tenant.Rooms))]
        public virtual Tenant CurrentTenant { get; set; }
        [ForeignKey(nameof(PropertyId))]
        [InverseProperty(nameof(Data.Property.Rooms))]
        public virtual Property Property { get; set; }
        [InverseProperty("Room")]
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        [InverseProperty("Room")]
        public virtual ICollection<RoomAllotment> RoomAllotments { get; set; }
    }
}

