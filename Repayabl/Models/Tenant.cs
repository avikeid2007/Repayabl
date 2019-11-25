using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        public int? Zip { get; set; }
        public int? FamilyMamberCount { get; set; }

        [InverseProperty("Tenant")]
        public virtual ICollection<FamilyDetail> FamilyDetails { get; set; }
        [InverseProperty("PaidByNavigation")]
        public virtual ICollection<RentTransaction> RentTransactions { get; set; }
        [InverseProperty("CurrentTenant")]
        public virtual ICollection<Room> Rooms { get; set; }
        [InverseProperty("Tenant")]
        public virtual ICollection<TenantDocument> TenantDocuments { get; set; }
        [InverseProperty("Tenant")]
        public virtual ICollection<TenantOutstanding> TenantOutstandings { get; set; }
    }
}
