namespace RoomBooking.Api.Dtos.Responses
{
    public class GetRoomsResponse
    {
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}
