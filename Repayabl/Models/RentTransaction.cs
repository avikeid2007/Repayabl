using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class RentTransaction : Auditor
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int BillYear { get; set; }
        public int BillMonth { get; set; }
        public int CurrentReading { get; set; }
        public int PreviousReading { get; set; }
        public decimal ElectricityBillAmount { get; set; }
        public decimal RentAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public Guid? PaidBy { get; set; }
        public decimal? PaidAmount { get; set; }
        public int TotalPaybleMonth { get; set; }

        public virtual Tenant PaidByNavigation { get; set; }
        public virtual Room Room { get; set; }
    }
}
