using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Properties : Auditor
    {
        public Properties()
        {
            Rooms = new HashSet<Rooms>();
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public int FloorCount { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
