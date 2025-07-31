using Advertising_platforms.Features.AdPlatform.GetAdPlatforms;
using Advertising_platforms.Features.AdPlatform.LoadFile;
using Advertising_platforms.Features.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertising_platforms.Features.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdPlatformsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdPlatformsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("load")]
        public async Task<IActionResult> LoadFile([FromBody] LoadFileRequest file)
        {
            if (file == null || string.IsNullOrEmpty(file.FileBase64))
                return BadRequest("Файл отсутствует или пуст.");

            byte[] fileBytes;
            try
            {
                fileBytes = Convert.FromBase64String(file.FileBase64);
            }
            catch
            {
                return BadRequest("Некорректный формат файла.");
            }

            var result = await _mediator.Send(new LoadAdPlatformsCommand(file));

            return result ? Ok("Файл успешно загружен.") : BadRequest("Ошибка загрузки файла.");
        }

        [Authorize]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string location)
        {
            var platforms = await _mediator.Send(new GetAdPlatformsQuery(location));
            return Ok(platforms);
        }
    }
}