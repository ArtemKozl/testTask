
namespace testTask.DataAccess.Repositories
{
    public interface ISpecializationsRepository
    {
        Task<string> GetValueById(int id);
        Task<int> NameExist(string name);
    }
}