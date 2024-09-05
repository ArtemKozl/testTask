using testTask.Core.Models;

namespace testTask.DataAccess.Repositories
{
    public interface IPatiensRepository
    {
        Task Add(Patiens patient);
        Task DeleteById(int id);
        Task Editing(Patiens patient);
        Task<List<Patiens>> GetList(string columnForSorting, int page);
        Task<Patiens> GetPatientsById(int id);
    }
}