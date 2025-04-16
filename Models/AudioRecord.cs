namespace AudioEmotionApp.Models
{
    public class AudioRecord
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? Emotion { get; set; } // <-- Lägger till detta
        public DateTime UploadedAt { get; set; } = DateTime.Now;
        public DateTime ProcessedAt { get; set; } = DateTime.Now; // <-- Och detta
    }
}
