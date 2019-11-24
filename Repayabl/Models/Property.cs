using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Property : Auditor
    {
        public Property()
        {
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
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

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
