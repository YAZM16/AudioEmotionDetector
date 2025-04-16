// AudioUploadValidator.cs
using FluentValidation;
using AudioEmotionApp.Models;
using AudioEmotionApp.Data;
namespace AudioEmotionApp.Validators
{
    public class AudioUploadValidator : AbstractValidator<AudioUploadDto>
    {
        public AudioUploadValidator()
        {
            RuleFor(x => x.AudioFile)
                .NotNull().WithMessage("Audio file must be provided.")
                .Must(file => file.Length > 0).WithMessage("Audio file cannot be empty.");
        }
    }
}
