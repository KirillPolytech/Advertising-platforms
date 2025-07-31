using Advertising_platforms.Features.AdPlatform.LoadFile;
using Advertising_platforms.Services.Interfaces;
using MediatR;

namespace Advertising_platforms.Features.AdPlatform.GetAdPlatforms
{
    public class GetAdPlatformsQueryHandler : IRequestHandler<GetAdPlatformsQuery, List<string>>
    {
        private readonly IAdPlatformService _accountService;

        public GetAdPlatformsQueryHandler(IAdPlatformService accountService)
        {
            _accountService = accountService;
        }

        public async Task<List<string>> Handle(GetAdPlatformsQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountService.GetPlatformsForLocation(request.Location);
            return await Task.FromResult(result);
        }
    }
}