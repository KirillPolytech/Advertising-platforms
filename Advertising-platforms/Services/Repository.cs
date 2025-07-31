using Advertising_platforms.Features.Models;
using Advertising_platforms.Services.Interfaces;

namespace Advertising_platforms.Services
{
    public class Repository : IRepository
    {
        public List<AdPlatform> Platforms { get; set; }

        public Repository()
        {
            Platforms = [];
        }
    }
}