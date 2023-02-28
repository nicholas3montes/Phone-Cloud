using Microsoft.EntityFrameworkCore;
using Phone_Cloud.Data;
using Phone_Cloud.models;
using Phone_Cloud.Repository;

namespace Phone_Cloud.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbUserContext _context;

        public UserRepository(DbUserContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }


        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            return _context.Users.Update(user);
        }

        public async Task<User> Delete(int id)
        {
            return _context.Users.Remove(_context.Users.Find(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}