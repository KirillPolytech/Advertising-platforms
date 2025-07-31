namespace Advertising_platforms.Features.Models
{
    public class AdPlatform
    {
        public required string Name { get; set; }
        public List<string> Locations { get; set; } = [];
    }
}