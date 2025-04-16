using AudioEmotionApp.Models;
using Microsoft.EntityFrameworkCore;
using AudioEmotionApp.Data;

namespace AudioEmotionApp.Mapping;

public static class DataSeeder
{
    public static void SeedDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        

        // Kontrollera om det redan finns data
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Username = "admin", Email = "admin@example.com", PasswordHash = "dummyHash", Role = "Admin" },
                new User { Username = "user", Email = "user@example.com", PasswordHash = "dummyHash", Role = "User" }
            );
        }

        if (!context.AudioRecords.Any())
        {
            context.AudioRecords.AddRange(
                new AudioRecord
                {
                    FileName = "test1.wav",
                    FilePath = "uploads/test1.wav",
                    Emotion = "Happy",
                    UploadedAt = DateTime.UtcNow
                },
                new AudioRecord
                {
                    FileName = "test2.wav",
                    FilePath = "uploads/test2.wav",
                    Emotion = "Angry",
                    UploadedAt = DateTime.UtcNow
                }
            );
        }

        context.SaveChanges();
    }
}
