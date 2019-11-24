using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Tenant : Auditor
    {
        public Tenant()
        {
            FamilyDetails = new HashSet<FamilyDetail>();
            RentTransactions = new HashSet<RentTransaction>();
            Rooms = new HashSet<Room>();
            TenantDocuments = new HashSet<TenantDocument>();
            TenantOutstandings = new HashSet<TenantOutstanding>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Zip { get; set; }
        public int? FamilyMamberCount { get; set; }

        public virtual ICollection<FamilyDetail> FamilyDetails { get; set; }
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<TenantDocument> TenantDocuments { get; set; }
        public virtual ICollection<TenantOutstanding> TenantOutstandings { get; set; }
    }
}
