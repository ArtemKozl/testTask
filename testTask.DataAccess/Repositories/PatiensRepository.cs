using AutoMapper;
using Microsoft.EntityFrameworkCore;
using testTask.Core.Models;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess.Repositories
{
    public class PatiensRepository : IPatiensRepository
    {
        private testTaskDbContext _context;
        private IMapper _mapper;
        public PatiensRepository(testTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Patiens patient)
        {
            var patientEntity = new PatiensEntity()
            {
                first_name = patient.First_name,
                second_name = patient.Second_name,
                middle_name = patient.Middle_name,
                address = patient.Address,
                date_of_bith = patient.Date_of_bith,
                gender = patient.Gender,
                district_id = patient.District_id,
            };
            await _context.Patiens.AddAsync(patientEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Editing(Patiens patient)
        {
            var patientEntity = await _context.Patiens.FindAsync(patient.Id);

            if (patientEntity == null)
            {
                throw new InvalidOperationException($"Patient with id {patient.Id} not found.");
            }

            patientEntity.first_name = patient.First_name;
            patientEntity.second_name = patient.Second_name;
            patientEntity.middle_name = patient.Middle_name;
            patientEntity.address = patient.Address;
            patientEntity.date_of_bith = patient.Date_of_bith;
            patientEntity.gender = patient.Gender;
            patientEntity.district_id = patient.District_id;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            PatiensEntity? patiensEntity = await _context.Patiens.FindAsync(id);

            if (patiensEntity != null)
            {
                _context.Patiens.Remove(patiensEntity);

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Patiens>> GetList(string columnForSorting, int page)
        {
            var pageSize = 10;
            var skipCount = (page - 1) * pageSize;

            var sql = $"select top 10 * from Patiens" +
                $" where id in (select id from Patiens " +
                $"ORDER BY id " +
                $"offset {skipCount} rows) " +
                $"order by {columnForSorting}";

            var patiensEntities = await _context.Patiens.FromSqlRaw(sql).ToListAsync();

            List<Patiens> patiens = new List<Patiens>();

            foreach (var patiensEntity in patiensEntities)
            {
                Patiens patient = new Patiens(patiensEntity.id, patiensEntity.second_name, patiensEntity.first_name, patiensEntity.middle_name
                    , patiensEntity.address, patiensEntity.date_of_bith, patiensEntity.gender, patiensEntity.district_id);

                patiens.Add(patient);
            }

            return patiens;
        }

        public async Task<Patiens> GetPatientsById(int id)
        {
            var patient = await _context.Patiens.FindAsync(id);

            return _mapper.Map<Patiens>(patient);
        }
    }
}
