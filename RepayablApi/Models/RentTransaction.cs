using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class RentTransaction : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }
        [Required]
        [StringLength(50)]
        public string BillNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BillDate { get; set; }
        public int BillYear { get; set; }
        public int BillMonth { get; set; }
        public int CurrentReading { get; set; }
        public int PreviousReading { get; set; }
        [Column(TypeName = "numeric(8, 2)")]
        public decimal ElectricityBillAmount { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal RentAmount { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal TotalAmount { get; set; }
        public bool? IsPaid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaidDate { get; set; }
        public int? PaidBy { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? PaidAmount { get; set; }
        public int TotalPaybleMonth { get; set; }

        [ForeignKey(nameof(PaidBy))]
        [InverseProperty(nameof(Tenant.RentTransactions))]
        public virtual Tenant PaidByNavigation { get; set; }
        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Models.Room.RentTransactions))]
        public virtual Room Room { get; set; }
    }
}
