using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly KataHotelContext _context;

        public UserDataAccess()
        {
            _context = new KataHotelContext(); 
        }
        
        public async Task<UserEntity> GetUser(int id)
        {
            return await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> AddUser(UserEntity user)
        {
            await _context.Users.AddAsync(user).ConfigureAwait(false);
            return _context.SaveChanges();
        }

        public async Task<int> EditUser(UserEntity user)
        {
            UserEntity UserToEdit = await _context.Users.Where(b => b.Id == user.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (UserToEdit != null)
                UserToEdit = user;

            return _context.SaveChanges();
        }

        public async Task<int> DeleteUser(int id)
        {
            UserEntity UserToDelete = await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (UserToDelete != null)
                _context.Users.Remove(UserToDelete);

            return _context.SaveChanges();
        }

        public Task<List<UserEntity>> GetUsers()
        {
            return _context.Users.ToListAsync();
        }
    }
}
