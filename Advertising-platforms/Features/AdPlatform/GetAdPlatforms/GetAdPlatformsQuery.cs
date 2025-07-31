using MediatR;

namespace Advertising_platforms.Features.AdPlatform.GetAdPlatforms
{
public record GetAdPlatformsQuery(string Location) : IRequest<List<string>>;
}