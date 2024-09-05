using testTask.Core.Models;

namespace testTask.DataAccess.Repositories
{
    public interface IDoctorsRepository
    {
        Task Add(Doctors doctor);
        Task DeleteById(int id);
        Task Editing(Doctors doctor);
        Task<Doctors> GetDoctorById(int id);
        Task<List<Doctors>> GetList(string columnForSorting, int page);
    }
}