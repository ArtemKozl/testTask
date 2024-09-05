using testTask.Core.Models;

namespace testTask.Application.Services
{
    public interface IDoctorService
    {
        Task AddDoctor(string full_name, int district_number, int office_number, string specialization_name);
        Task DeleteDoctor(int id);
        Task EditingDoctor(int id, string full_name, int district_number, int office_number, string specialization_name);
        Task<object> GetDoctorBtId(int id);
        Task<List<DoctorsForOutputList>> GetDoctorsList(string columnForSorting, int page);
    }
}