using Advertising_platforms.Features.Models;

namespace Advertising_platforms.Services.Interfaces
{
    public interface IRepository
    {
        public List<AdPlatform> Platforms { get; set; }
    }
}