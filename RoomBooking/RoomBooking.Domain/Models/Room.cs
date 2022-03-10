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

        public string Name { get; set; }
    }
}
