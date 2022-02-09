using System;
using System.Collections.Generic;

namespace RoomBooking.Domain.Models
{
    public class BookingDom
    {
        public BookingDom()
        {

        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int StartSlot { get; set; }
        public int EndSlot { get; set; }
    }
}
