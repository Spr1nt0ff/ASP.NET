using homework.Models;

namespace homework.Repository
{
    public interface IRepository
    {
        Task<List<Users>> GetUsersList();
        Task<Users> GetUser(int id);
        Task<Users> GetUserByLogin(string login);
        Task Create(Users item);
        void Update(Users item);
        Task Delete(int id);
        Task Save();
    }
}