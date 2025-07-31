using FluentValidation;

namespace Advertising_platforms.Features.AdPlatform.GetAdPlatforms
{
    public class GetAdPlatformsQueryValidator : AbstractValidator<GetAdPlatformsQuery>
    {
        public GetAdPlatformsQueryValidator()
        {
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .Must(loc => loc.StartsWith('/')).WithMessage("The location must start from '/'.");
        }
    }
}