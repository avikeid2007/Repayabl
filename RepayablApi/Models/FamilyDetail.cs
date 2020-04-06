using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class FamilyDetail : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public int TenantId { get; set; }
        [StringLength(50)]
        public string Relationship { get; set; }

        [ForeignKey(nameof(TenantId))]
        [InverseProperty(nameof(Models.Tenant.FamilyDetails))]
        public virtual Tenant Tenant { get; set; }
    }
}
