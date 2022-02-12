using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;

namespace RoomBooking.Dal.Repositories
{
    public class ValueRepository : IValueRepository
    {
        private readonly KataHotelContext _context;

        public ValueRepository(KataHotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Value>> GetValuesAsync()
        {
            var a = await _context.Users.ToListAsync();
            var values = await Task.Run(() => new List<ValueEntity>
            {
                new ValueEntity
                {
                    Id = 1,
                    Name = "Name"
                }
            });

            return values.Select(t => new Value
            {
                Id = t.Id,
                Name = t.Name
            });
        }
    }

    public class ValueEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
