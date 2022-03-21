using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private Timer timer;
        private AutoResetEvent autoResetEvent;
        private Action action;
        public DateTime TimerStarted { get; set; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUserAsync(User user)
        {
            var a = await _userRepository.AddUserAsync(user);
            return a;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<int> EditUserAsync(User user)
        {
            return await _userRepository.EditUserAsync(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            action = action;
            autoResetEvent = new AutoResetEvent(false);
            timer = new Timer(Execute, autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;

            return await _userRepository.GetUsersAsync();
        }

        public void Execute(object stateInfo)
        {
           // action();
            //if ((DateTime.Now - TimerStarted).Seconds > 60)
            //{
            //    timer.Dispose();
            //}

        }
    }
}
