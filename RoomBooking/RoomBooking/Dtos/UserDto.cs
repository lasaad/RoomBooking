using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Api.Dtos.Responses
{
    public class UserDto
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z\s]*$")]
        public string LastName { get; set; }
    }
}
