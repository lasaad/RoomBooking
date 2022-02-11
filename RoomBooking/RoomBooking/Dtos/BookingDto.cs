using System;
using System.Collections.Generic;

namespace RoomBooking.Api.Dtos.Responses
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int StartSlot { get; set; }
        public int EndSlot { get; set; }
    }
}
