using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Users : Auditor
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAuth { get; set; }
        public bool IsAdmin { get; set; }
        public Guid RoomId { get; set; }
        public Guid PropertyId { get; set; }

        public virtual Properties Property { get; set; }
        public virtual Rooms Room { get; set; }
    }
}
