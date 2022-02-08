using System;
using System.Collections.Generic;

namespace RoomBooking.Dal.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
