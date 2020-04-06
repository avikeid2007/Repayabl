using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models.DTOs
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        public int? RoomFloorNo { get; set; }
        public int PropertyId { get; set; }
        public int? CurrentTenantId { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal MonthlyRent { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal ElectRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastBillPaidDate { get; set; }
        public int? LastPaidBillId { get; set; }
    }
}