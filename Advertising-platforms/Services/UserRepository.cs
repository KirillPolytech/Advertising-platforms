using Advertising_platforms.Features.Models;
using Advertising_platforms.Services.Interfaces;

namespace Advertising_platforms.Services
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = new List<User>
            {
                new User { Username = "admin", Password = "admin", Role = "admin" },
                new User { Username = "user", Password = "user", Role = "user" }
            };
        }
    }
}