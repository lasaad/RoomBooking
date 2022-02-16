using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Models
{
    public class Room
    {
        public Room()
        {

        }

        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s 1-9]*$")]
        public string Name { get; set; }
    }
}
