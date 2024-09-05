
namespace testTask.DataAccess.Repositories
{
    public interface IDistrictsRepository
    {
        Task<int> GetValueById(int id);
        Task<int> NumberExist(int number);
    }
}