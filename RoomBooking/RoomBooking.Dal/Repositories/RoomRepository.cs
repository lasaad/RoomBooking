using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;

namespace RoomBooking.Dal.DataAccess
{
    public class RoomRepository : IRoomRepository
    {
        private readonly KataHotelContext _context;
        private readonly MapperConfiguration _mapper;

        public RoomRepository(KataHotelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Room, RoomEntity>();
                cfg.CreateMap<RoomEntity, Room>();
            });
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Rooms.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            Room roomDTO = mapper.Map<Room>(a);

            return roomDTO;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Rooms.ToListAsync().ConfigureAwait(false);
            List<Room> roomDTO = mapper.Map<List<Room>>(a);

            return roomDTO;
        }

        public async Task<int> EditRoomAsync(Room room)
        {
            Mapper mapper = new(_mapper);

            RoomEntity roomDTO = mapper.Map<RoomEntity>(room);
            RoomEntity? roomToEdit = await _context.Rooms.Where(b => b.Id == roomDTO.Id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (roomToEdit != null)
                roomToEdit = roomDTO;

            return _context.SaveChanges();
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            Mapper mapper = new(_mapper);
            RoomEntity roomEntity = mapper.Map<RoomEntity>(room);
            await _context.Rooms.AddAsync(roomEntity).ConfigureAwait(false);

            return _context.SaveChanges();
        }

        public async Task<int> DeleteRoomAsync(int id)
        {
            Mapper mapper = new(_mapper);
            RoomEntity? roomToDelete = await _context.Rooms.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (roomToDelete != null)
                _context.Rooms.Remove(roomToDelete);

            return _context.SaveChanges();
        }
    }
}
