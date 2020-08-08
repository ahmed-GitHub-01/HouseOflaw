using System.Collections.Generic;
using System.Threading.Tasks;
using HouseOflaw.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOflaw.API.Data
{
    public class DatingRepo : IDatingRepo
    {
        private readonly DataContext _context;
        public DatingRepo(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<User> GetUser(double Code)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Code == Code);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var Users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return Users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}