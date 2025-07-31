using Advertising_platforms.Features.Models;

namespace Advertising_platforms.Services.Interfaces
{
    public interface IUserRepository
    {
        public List<User> Users { get; set; }
    }
}