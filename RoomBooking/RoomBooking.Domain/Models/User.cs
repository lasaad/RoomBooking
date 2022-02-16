using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Models
{
    public class User        
    {
        public User()
        {

        }

        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\sÀ-ÿ]*$")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-ZÀ-Ü\s]*$")]
        public string LastName { get; set; }

    }
}
