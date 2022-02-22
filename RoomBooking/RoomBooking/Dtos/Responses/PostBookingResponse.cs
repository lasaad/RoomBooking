namespace RoomBooking.Api.Dtos.Responses
{
    public class PostBookingResponse
    {
        public bool IsAvailable { get; set; }

        public List<int> AvailableHours { get; set; }
    }
}
