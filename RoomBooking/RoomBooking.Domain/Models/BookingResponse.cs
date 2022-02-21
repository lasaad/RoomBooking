using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain.Models
{
    public class BookingResponse
    {
        public bool IsAvailable { get; set; }

        public List<int> AvailableHours { get; set; }   

    }
}
