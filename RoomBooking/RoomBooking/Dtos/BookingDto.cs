using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Api.Dtos.Responses
{
    public class BookingDto
    {      
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
