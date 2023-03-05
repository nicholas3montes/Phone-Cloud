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
            return await _context.Users.OrderBy(user => user.Id).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(idUser => idUser.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);    
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}