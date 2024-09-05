using AutoMapper;
using testTask.Core.Models;
using testTask.DataAccess.Entities;

namespace testTask.infrastructure
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<DoctorsEntity, Doctors>();
            CreateMap<PatiensEntity, Patiens>();
        }
    }
}
