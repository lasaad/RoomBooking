namespace RoomBooking.Api.Dtos.Responses
{
    public class GetBookingsResponse
    {
        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}
