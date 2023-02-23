
using Phone_Cloud.models;

namespace Phone_Cloud.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        Task<bool> SaveChangesAsync();
    }
}