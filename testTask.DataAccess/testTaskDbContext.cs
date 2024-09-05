using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTask.DataAccess.Entities;

namespace testTask.DataAccess
{
    public class testTaskDbContext : DbContext
    {
        public testTaskDbContext(DbContextOptions<testTaskDbContext> options)
            : base(options)
        {

        }

        public DbSet<SpecializationsEntity> Specializations { get; set; }
        public DbSet<PatiensEntity> Patiens { get; set; }
        public DbSet<OfficesEntity> Offices { get; set; }
        public DbSet<DoctorsEntity> Doctors { get; set; }
        public DbSet<DistrctsEntity> Districts { get; set; }
    }
}
