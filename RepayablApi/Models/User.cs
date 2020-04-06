using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepayablApi.Models
{
    public partial class User : Auditor
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAuth { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
