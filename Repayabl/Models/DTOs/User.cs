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
        public bool IsAdmin { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public virtual Room Room { get; set; }
    }
}
