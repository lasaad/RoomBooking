using System;
using System.Collections.Generic;

namespace RoomBooking.Domain.Models
{
    public class User        
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
