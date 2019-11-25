using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class User : Auditor
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuth { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Property> Properties { get; set; }

    }
   
}
