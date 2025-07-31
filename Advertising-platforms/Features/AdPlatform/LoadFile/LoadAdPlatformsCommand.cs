using Advertising_platforms.Features.Models;
using MediatR;

namespace Advertising_platforms.Features.AdPlatform.LoadFile
{
    public record LoadAdPlatformsCommand(LoadFileRequest LoadFileRequest) : IRequest<bool>;
}