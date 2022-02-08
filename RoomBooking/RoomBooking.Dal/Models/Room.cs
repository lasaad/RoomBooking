using System;
using System.Collections.Generic;

namespace RoomBooking.Dal.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
