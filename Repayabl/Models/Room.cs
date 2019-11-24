using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Room: Auditor
    {
        public Room()
        {
            RentTransactions = new HashSet<RentTransaction>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string RoomNo { get; set; }
        public int? RoomFloorNo { get; set; }
        public Guid PropertyId { get; set; }
        public Guid CurrentTenantId { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal ElectRate { get; set; }
        public DateTime? LastBillPaidDate { get; set; }
        public Guid? LastPaidBillId { get; set; }

        public virtual Tenant CurrentTenant { get; set; }
        public virtual Property Property { get; set; }
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
