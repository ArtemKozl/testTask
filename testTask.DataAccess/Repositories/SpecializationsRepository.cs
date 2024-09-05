using Microsoft.EntityFrameworkCore;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess.Repositories
{
    public class SpecializationsRepository : ISpecializationsRepository
    {
        private testTaskDbContext _context;
        public SpecializationsRepository(testTaskDbContext context)
        {
            _context = context;
        }
        public async Task<int> NameExist(string name)
        {
            var result = await _context.Specializations.FirstOrDefaultAsync(x => x.name == name);
            if (result == null)
            {
                var specializationEntity = new SpecializationsEntity()
                {
                    name = name,
                };

                await _context.Specializations.AddAsync(specializationEntity);
                await _context.SaveChangesAsync();

                return specializationEntity.id;
            }
            else
            {
                return result.id;
            }
        }

        public async Task<string> GetValueById(int id)
        {
            var result = await _context.Specializations.FirstOrDefaultAsync(x => x.id == id);

            if (result == null)
                throw new Exception("Id does not exist");

            return result.name;
        }
    }
}
