// AudioProcessingResultDto.cs
namespace AudioEmotionApp.Models
{
    public class AudioProcessingResultDto
    {
        public string FileName { get; set; } = string.Empty;
        public string EmotionDetected { get; set; } = string.Empty;
        public DateTime ProcessedAt { get; set; }
    }
}