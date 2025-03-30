using homework.Models;
using Microsoft.EntityFrameworkCore;

namespace homework.Repository
{
    public class UserRepository : IRepository
    {
        private readonly GuestBookContext _context;
        public UserRepository(GuestBookContext context)
        {
            _context = context;
        }
        public async Task<List<Users>> GetUsersList()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<Users> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<Users> GetUserByLogin(string login)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Login == login);
        }
        public async Task Create(Users item)
        {
            await _context.User.AddAsync(item);
        }
        public void Update(Users item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Users item = await _context.User.FindAsync(id);
            if (item != null)
            {
                _context.User.Remove(item);
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}