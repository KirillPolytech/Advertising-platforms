using Advertising_platforms.Features.AdPlatform.LoadFile;
using Advertising_platforms.Features.Models;
using Advertising_platforms.Services.Interfaces;
using System.Text;

namespace Advertising_platforms.Services
{
    public class AdPlatformService : IAdPlatformService
    {
        private readonly ReaderWriterLockSlim _lock = new();
        private readonly IRepository _repository;

        public AdPlatformService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> LoadFromFile(LoadAdPlatformsCommand file)
        {
            var bytes = Convert.FromBase64String(file.LoadFileRequest.FileBase64);
            var text = Encoding.UTF8.GetString(bytes);
            var lines = text.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries);

            var platforms = new List<AdPlatform>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || !line.Contains(':')) 
                    continue;

                var parts = line.Split(':', 2);
                var name = parts[0].Trim();
                var locations = parts[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Where(loc => loc.StartsWith('/'))
                    .ToList();

                if (!string.IsNullOrWhiteSpace(name) && locations.Any())
                    platforms.Add(new AdPlatform { Name = name, Locations = locations });
            }

            _lock.EnterWriteLock();
            try
            {
                _repository.Platforms.Clear();
                _repository.Platforms.AddRange(platforms);

                return await Task.FromResult(true);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public Task<List<string>> GetPlatformsForLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location) || !location.StartsWith('/'))
                return Task.FromResult(new List<string>());

            _lock.EnterReadLock();
            try
            {
                return Task.FromResult(_repository.Platforms
                    .Where(p => p.Locations.Any(location.StartsWith))
                    .Select(p => p.Name)
                    .Distinct()
                    .ToList());
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}