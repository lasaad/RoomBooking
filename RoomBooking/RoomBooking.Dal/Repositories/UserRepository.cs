using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;

namespace RoomBooking.Dal.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly KataHotelContext _context;
        private readonly MapperConfiguration _mapper;

        public UserRepository(KataHotelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity,User>();
            } /*cfg.CreateMap<User, UserEntity>()*/);
        }

        public async Task<User> GetUserAsync(int id)
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            User userDTO = mapper.Map<User>(a);

            return userDTO;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Users.ToListAsync().ConfigureAwait(false);
            List<User> userDTO = mapper.Map<List<User>>(a);

            return userDTO;
        }

        public async Task<int> EditUserAsync(User user)
        {
            Mapper mapper = new(_mapper);

            UserEntity userDTO = mapper.Map<User, UserEntity>(user);
            UserEntity? userToEdit = await _context.Users.Where(b => b.Id == userDTO.Id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (userToEdit != null)
                userToEdit = userDTO;

            return _context.SaveChanges();
        }

        public async Task<int> AddUserAsync(User user)
        {
            try
            {
                Mapper mapper = new(_mapper);
                UserEntity userEntity = new UserEntity();
                userEntity = mapper.Map<User, UserEntity>(user);
                await _context.Users.AddAsync(userEntity).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                var a = e;
                
            }
            return _context.SaveChanges();

        }

        public async Task<int> DeleteUserAsync(int id)
        {
            Mapper mapper = new(_mapper);
            UserEntity? userToDelete = await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (userToDelete != null)
                _context.Users.Remove(userToDelete);

            return _context.SaveChanges();
        }
    }
}
