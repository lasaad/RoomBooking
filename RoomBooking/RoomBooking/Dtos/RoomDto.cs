using System;
using System.Collections.Generic;

namespace RoomBooking.Api.Dtos.Responses
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
