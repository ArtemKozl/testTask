﻿
namespace testTask.DataAccess.Repositories
{
    public interface IOfficesRepository
    {
        Task<int> GetValueById(int id);
        Task<int> NumberExist(int number);
    }
}