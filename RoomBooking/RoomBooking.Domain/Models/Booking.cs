using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Models
{
    public class Booking
    {
        public Booking()
        {

        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        [Range(0, 23)]
        public int StartSlot { get; set; }

        [Range(1, 23)]
        public int EndSlot { get; set; }
    }
}
