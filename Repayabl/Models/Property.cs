using System;
using System.Collections.Generic;

namespace Repayabl.Models
{
    public partial class Property : Auditor
    {
        public Property()
        {
            Rooms = new HashSet<Room>();
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
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        
    }
}
