using identity.api.Data;
using identity.api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.api.Data
{
    public class UsersRepository : IUsersRepository
    {
        private UsersContext _context;
        public UsersRepository(UsersContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Add(entity);
        }
        public void Update(User entity)
        {
            _context.Update(entity);
        }
        public void Delete(User entity)
        {
            _context.Remove(entity);
        }

        public async Task<User> User(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }


        public async Task<IEnumerable<User>> Users()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public bool UserExists(int id) {
            return _context.Users.Any(e => e.Id == id);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
