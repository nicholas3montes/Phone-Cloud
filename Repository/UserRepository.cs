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

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(idUser => idUser.Id == id).FirstOrDefaultAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}