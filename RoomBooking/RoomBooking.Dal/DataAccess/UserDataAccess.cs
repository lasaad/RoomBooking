using RoomBooking.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Dal.Interfaces;
using System.Data.Entity;

namespace UserBooking.Dal.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly KataHotelContext _context;

        public UserDataAccess(/*KataHotelContext context*/)
        {
            _context = new KataHotelContext(); 
        }
        
        public async Task<User> GetBooking(int id)
        {
            return await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user).ConfigureAwait(false);
            return _context.SaveChanges();
        }

        public async Task<int> EditUser(User user)
        {
            User UserToEdit = await _context.Users.Where(b => b.Id == user.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (UserToEdit != null)
                UserToEdit = user;

            return _context.SaveChanges();
        }

        public async Task<int> DeleteUser(int id)
        {
            User UserToDelete = await _context.Users.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (UserToDelete != null)
                _context.Users.Remove(UserToDelete);

            return _context.SaveChanges();
        }
    }
}
