// AudioEmotionAppController.cs
using Microsoft.AspNetCore.Mvc;
using AudioEmotionApp.Models;
using AudioEmotionApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace AudioEmotionApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AudioEmotionAppController : ControllerBase
    {
        private readonly IAudioService _audioService;

        public AudioEmotionAppController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAudio([FromForm] AudioUploadDto audioDto)
        {
            if (audioDto.AudioFile == null || audioDto.AudioFile.Length == 0)
                return BadRequest("Audio file is required.");

            var result = await _audioService.ProcessAudioAsync(audioDto);
            return Ok(result);
        }
    }
}