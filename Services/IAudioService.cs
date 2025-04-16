// IAudioService.cs
using AudioEmotionApp.Models;

namespace AudioEmotionApp.Services
{
    public interface IAudioService
    {
        Task<AudioProcessingResultDto> ProcessAudioAsync(AudioUploadDto dto);
    }
}
