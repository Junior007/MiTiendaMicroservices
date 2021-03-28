using System.Collections.Generic;
using identity.api.Model;
using Microsoft.EntityFrameworkCore;

namespace identity.api.Data
{
    public class UsersContext:DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options):base(options){}

        public DbSet<User> Users{get;set;}

    }
    //
}