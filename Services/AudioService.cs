// AudioService.cs
using AudioEmotionApp.Models;
using AudioEmotionApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AudioEmotionApp.Services
{
    public class AudioService : IAudioService
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _db;

        public AudioService(IWebHostEnvironment env, AppDbContext db)
        {
            _env = env;
            _db = db;
        }

        public async Task<AudioProcessingResultDto> ProcessAudioAsync(AudioUploadDto dto)
        {
            var webRootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsFolder = Path.Combine(webRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, dto.AudioFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.AudioFile.CopyToAsync(stream);
            }

            var emotion = "Happy";

            var record = new AudioRecord
            {
                FileName = dto.AudioFile.FileName,
                Emotion = emotion,
                ProcessedAt = DateTime.Now
            };

            _db.AudioRecords.Add(record);
            await _db.SaveChangesAsync();

            return new AudioProcessingResultDto
            {
                FileName = record.FileName,
                EmotionDetected = record.Emotion,
                ProcessedAt = record.ProcessedAt
            };
        }
       
    }
}