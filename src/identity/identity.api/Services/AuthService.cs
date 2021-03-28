using identity.api.Data;
using identity.api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace identity.api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UsersContext _dataContext;
        //
        public AuthService(UsersContext context)
        {
            this._dataContext = context;
        }
        //
        public async Task<User> Login(string username, string password)
        {

            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }
        //
        public async Task<bool> UserExists(string username)
        {
            if (await _dataContext.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
        //
        public async Task<User> Register(User user, string password)
        {


            user.Username = user.Username.ToLower();

            if (await UserExists(user.Username))
                throw new Exception("Username already exists");


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
        //
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        //
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                if (passwordHash.Length != passwordHash.Length)
                    return false;

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

    }
}