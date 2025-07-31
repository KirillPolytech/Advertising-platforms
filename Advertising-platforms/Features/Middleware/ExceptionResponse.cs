using System.Net;

namespace Advertising_platforms.Features.Middleware
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}