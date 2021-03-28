using identity.api.Model;
using identity.api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.api.Data
{
    public class Seed
    {
        public static void SeedUsers(UsersContext context, IAuthService authService) {

            // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
            context.Database.Migrate();
            context.Database.EnsureCreated();

            if (!context.Users.Any()) {
                string usersData = System.IO.File.ReadAllText("Data/UserSeedDAta.json");
                var users = JsonConvert.DeserializeObject<List<User>>(usersData );
                foreach (var user in users) {
                    user.Username = user.Username.ToLower();
                    authService.Register(user, "password");
                }
            }
        
        }
    }
}
