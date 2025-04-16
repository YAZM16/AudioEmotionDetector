// AudioUploadDto.cs
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AudioEmotionApp.Models
{
    public class AudioUploadDto
    {
        [Required]
        public IFormFile? AudioFile { get; set; }
    }
}
