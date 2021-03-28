using System.ComponentModel.DataAnnotations;

namespace identity.api.Dtos
{
    public class UserForLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
