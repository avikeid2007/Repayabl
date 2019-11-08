using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class FamilyDetails
    {
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
        public Guid TenantId { get; set; }
        public string Relationship { get; set; }

        public virtual Tenants Tenant { get; set; }
    }
}
