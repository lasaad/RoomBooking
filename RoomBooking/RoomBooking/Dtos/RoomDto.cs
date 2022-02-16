using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Api.Dtos.Responses
{
    public class RoomDto
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }
    }
}
