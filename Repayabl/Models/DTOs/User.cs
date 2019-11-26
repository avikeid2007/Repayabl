using System;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Models.DTOs
{
    public partial class User
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
