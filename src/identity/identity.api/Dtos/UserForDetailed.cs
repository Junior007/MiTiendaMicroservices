using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.api.Dtos
{
    public class UserForDetailed
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActivity { get; set; }


    }
}
