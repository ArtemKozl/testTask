using testTask.Core.Models;

namespace testTask.Application.Services
{
    public interface IPatientService
    {
        Task AddPatient(string second_name, string first_name, string middle_name, string address, DateOnly date_of_bith, char gender, int district_number);
        Task DeletePatienr(int id);
        Task EditingPatient(int id, string second_name, string first_name, string middle_name, string address, DateOnly date_of_bith, char gender, int district_number);
        Task<object> GetPatientById(int id);
        Task<List<PatiensForOutputList>> GetPatientsList(string columnForSorting, int page);
    }
}