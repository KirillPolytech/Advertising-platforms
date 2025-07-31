using Advertising_platforms.Features.AdPlatform.LoadFile;

namespace Advertising_platforms.Services.Interfaces
{
    public interface IAdPlatformService
    {
        Task<bool> LoadFromFile(LoadAdPlatformsCommand file);
        Task<List<string>> GetPlatformsForLocation(string location);

    }
}