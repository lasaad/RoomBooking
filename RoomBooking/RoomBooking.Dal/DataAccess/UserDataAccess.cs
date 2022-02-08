using RoomBooking.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Dal.Interfaces;


namespace UserBooking.Dal.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly KataHotelContext _context;

        public UserDataAccess(/*KataHotelContext context*/)
        {
            _context = new KataHotelContext(); 
        }
        
        public User GetBooking(int id)
        {
            return _context.Users.Where(b => b.Id == id).FirstOrDefault();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        public int EditUser(User user)
        {
            User UserToEdit = _context.Users.Where(b => b.Id == user.Id).FirstOrDefault();
            if (UserToEdit != null)
                UserToEdit = user;

            return _context.SaveChanges();
        }

        public int DeleteUser(int id)
        {
            User UserToDelete = _context.Users.Where(b => b.Id == id).FirstOrDefault();

            if (UserToDelete != null)
                _context.Users.Remove(UserToDelete);

            return _context.SaveChanges();
        }
    }
}
