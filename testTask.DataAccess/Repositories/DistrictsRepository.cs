using Microsoft.EntityFrameworkCore;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess.Repositories
{
    public class DistrictsRepository : IDistrictsRepository
    {
        private testTaskDbContext _context;

        public DistrictsRepository(testTaskDbContext context)
        {
            _context = context;
        }

        public async Task<int> NumberExist(int number)
        {
            var result = await _context.Districts.FirstOrDefaultAsync(x => x.number == number);
            if (result == null)
            {
                var districtEntity = new DistrctsEntity()
                {
                    number = number,
                };

                await _context.Districts.AddAsync(districtEntity);
                await _context.SaveChangesAsync();

                return districtEntity.id;
            }
            else
            {
                return result.id;
            }
        }

        public async Task<int> GetValueById(int id)
        {
            var result = await _context.Districts.FirstOrDefaultAsync(x => x.id == id);

            if (result == null)
                throw new Exception("Id does not exist");

            return result.number;
        }
    }
}
