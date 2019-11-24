using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repayabl.Models.DTOs
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
