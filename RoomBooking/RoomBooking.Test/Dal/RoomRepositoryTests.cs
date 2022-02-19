using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Dal;
using RoomBooking.Dal.DataAccess;
using RoomBooking.Dal.Models;
using RoomBooking.Dal.Repositories;
using RoomBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Test.Dal
{
    [TestClass]
    public class RoomRepositoryTests
    {
        [TestMethod]
        public async Task Should_Get_Rooms()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<KataHotelContext>()
                .UseInMemoryDatabase("when_requesting_Rooms")
                .Options;
            IEnumerable<Room>? rooms = null;

            using (var ctx = new KataHotelContext(options))
            {
                var fakeRoomEntity = new RoomEntity
                {
                    Id = 1,
                    Name = "Test 1"
                };
                ctx.Rooms.Add(fakeRoomEntity);
                await ctx.SaveChangesAsync();
            }

            // Act
            using (var ctx = new KataHotelContext(options))
            {
                var roomRepository = new RoomRepository(ctx);
                rooms = await roomRepository.GetRoomsAsync();
            }

            // Assert
            Assert.IsNotNull(rooms);
            Assert.AreEqual(rooms.Count(), 1);
            Assert.AreEqual(rooms.Single().Name, "Test 1");
        }
    }
}
