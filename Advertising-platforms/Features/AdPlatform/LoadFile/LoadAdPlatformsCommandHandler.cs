using Advertising_platforms.Services.Interfaces;
using MediatR;

namespace Advertising_platforms.Features.AdPlatform.LoadFile
{
    public class LoadAdPlatformsCommandHandler : IRequestHandler<LoadAdPlatformsCommand, bool>
    {
        private readonly IAdPlatformService _accountService;

        public LoadAdPlatformsCommandHandler(IAdPlatformService accountService)
        {
            _accountService = accountService;
        }

        public async Task<bool> Handle(LoadAdPlatformsCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.LoadFromFile(request);
            return await Task.FromResult(result);
        }

    }
}