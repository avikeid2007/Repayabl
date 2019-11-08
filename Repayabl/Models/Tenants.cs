using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Tenants
    {
        public Tenants()
        {
            FamilyDetails = new HashSet<FamilyDetails>();
            RentTransactions = new HashSet<RentTransactions>();
            Rooms = new HashSet<Rooms>();
            TenantDocuments = new HashSet<TenantDocuments>();
            TenantOutstandings = new HashSet<TenantOutstandings>();
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

        public virtual ICollection<FamilyDetails> FamilyDetails { get; set; }
        public virtual ICollection<RentTransactions> RentTransactions { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<TenantDocuments> TenantDocuments { get; set; }
        public virtual ICollection<TenantOutstandings> TenantOutstandings { get; set; }
    }
}
