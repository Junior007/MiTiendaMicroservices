using identity.api.Model;
using System.Threading.Tasks;

namespace identity.api.Services
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        //Task<User> Login(User userToCreate, string password);
    }

}