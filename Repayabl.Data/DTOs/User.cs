using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repayabl.Data.DTOs
{
    public partial class User
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }

        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAuth { get; set; }
        public bool IsAdmin { get; set; }
        public string Context { get; set; }
        public string AzureId { get; set; }
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string UserPrincipalName { get; set; }

        public string JobTitle { get; set; }
        public string Mail { get; set; }
        public string MobilePhone { get; set; }
        public string OfficeLocation { get; set; }
        public string PreferredLanguage { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
