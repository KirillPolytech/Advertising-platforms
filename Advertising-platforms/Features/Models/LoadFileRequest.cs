namespace Advertising_platforms.Features.Models
{
    public class LoadFileRequest
    {
        public string FileName { get; set; } = null!;
        public string FileBase64 { get; set; } = null!;
    }
}