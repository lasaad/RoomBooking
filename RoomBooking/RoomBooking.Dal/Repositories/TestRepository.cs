using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;

namespace RoomBooking.Dal.Repositories
{
    public class TestRepository : ITestRepository
    {
        public async Task<IEnumerable<Test>> GetTestsAsync()
        {
            var tests = await Task.Run(() => new List<TestEntity>
            {
                new TestEntity
                {
                    Id = 1,
                    Name = "Name"
                }
            });

            return tests.Select(t => new Test
            {
                Id = t.Id,
                Name = t.Name
            });
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
