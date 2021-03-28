using identity.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.api.Data
{
    public interface IUsersRepository
    {
        void Add(User entity);
        void Delete(User entity);
        void Update(User entity);
        Task<bool> SaveAll();
        Task<IEnumerable<User>> Users();
        Task<User> User(int id);
        bool UserExists(int id);

    }
}
