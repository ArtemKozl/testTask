using Microsoft.EntityFrameworkCore;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess.Repositories
{
    public class OfficesRepository : IOfficesRepository
    {
        private testTaskDbContext _context;
        public OfficesRepository(testTaskDbContext context)
        {
            _context = context;
        }

        public async Task<int> NumberExist(int number)
        {
            var result = await _context.Offices.FirstOrDefaultAsync(x => x.number == number);
            if (result == null)
            {
                var officesEntity = new OfficesEntity()
                {
                    number = number,
                };

                await _context.Offices.AddAsync(officesEntity);
                await _context.SaveChangesAsync();

                return officesEntity.id;
            }
            else
            {
                return result.id;
            }
        }

        public async Task<int> GetValueById(int id)
        {
            var result = await _context.Offices.FirstOrDefaultAsync(x => x.id == id);

            if (result == null)
                throw new Exception("Id does not exist");

            return result.number;
        }
    }
}
