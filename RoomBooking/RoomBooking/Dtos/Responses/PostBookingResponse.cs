namespace RoomBooking.Api.Dtos.Responses
{
    public class PostBookingResponse
    {
        public bool IsAvailable { get; set; }

        public IEnumerable<int> AvailableHours { get; set; }
    }
}
