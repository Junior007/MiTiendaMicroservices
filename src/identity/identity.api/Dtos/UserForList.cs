using System;

namespace identity.api.Dtos
{
    public class UserForList
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActivity { get; set; }

    }
}
