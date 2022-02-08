using System;
using System.Collections.Generic;

namespace RoomBooking.Dal.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int StartSlot { get; set; }
        public int EndSlot { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
