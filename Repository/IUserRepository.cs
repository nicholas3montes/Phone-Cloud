
using Phone_Cloud.models;

namespace Phone_Cloud.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<bool> SaveChangesAsync();

        Task<User> GetById(int id);

        Task<User> Delete(int id);

        Task<List<User>> GetAll();

    }
}