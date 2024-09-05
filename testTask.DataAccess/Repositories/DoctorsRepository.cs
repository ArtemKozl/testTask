using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using testTask.Core.Models;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private testTaskDbContext _context;
        private IMapper _mapper;

        public DoctorsRepository(testTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Doctors doctor)
        {
            var doctorEntity = new DoctorsEntity()
            {
                full_name = doctor.Full_name,
                office_id = doctor.Office_id,
                specialization_id = doctor.Specialization_id,
                district_id = doctor.District_id
            };
            await _context.Doctors.AddAsync(doctorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Editing(Doctors doctor)
        {
            var doctorEntity = await _context.Doctors.FindAsync(doctor.Id);

            if (doctorEntity == null)
            {
                throw new InvalidOperationException($"Doctor with id {doctor.Id} not found.");
            }

            doctorEntity.full_name = doctor.Full_name;
            doctorEntity.office_id = doctor.Office_id;
            doctorEntity.specialization_id = doctor.Specialization_id;
            doctorEntity.district_id = doctor.District_id;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            DoctorsEntity? doctorEntity = await _context.Doctors.FindAsync(id);

            if (doctorEntity != null)
            {
                _context.Doctors.Remove(doctorEntity);

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Doctors>> GetList(string columnForSorting, int page)
        {
            var pageSize = 10;
            var skipCount = (page - 1) * pageSize;

            var sql = $"select top 10 * from Doctors" +
                $" where id in (select id from Doctors " +
                $"ORDER BY id " +
                $"offset {skipCount} rows) " +
                $"order by {columnForSorting}";

            var doctorsEntities = await _context.Doctors.FromSqlRaw(sql).ToListAsync();

            List<Doctors> doctors = new List<Doctors>();

            foreach ( var doctorEntity in doctorsEntities)
            {
                Doctors doctor = new Doctors(doctorEntity.id, doctorEntity.full_name, doctorEntity.office_id, doctorEntity.specialization_id, doctorEntity.district_id);

                doctors.Add(doctor);
            }

            return doctors;
        }

        public async Task<Doctors> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            return _mapper.Map<Doctors>(doctor);
        }


    }
}
