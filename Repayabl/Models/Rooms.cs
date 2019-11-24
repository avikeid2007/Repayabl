using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Rooms: Auditor
    {
        public Rooms()
        {
            RentTransactions = new HashSet<RentTransactions>();
            Users = new HashSet<Users>();
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

        public virtual Tenants CurrentTenant { get; set; }
        public virtual Properties Property { get; set; }
        public virtual ICollection<RentTransactions> RentTransactions { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
