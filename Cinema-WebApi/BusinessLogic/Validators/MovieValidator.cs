using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class MovieValidator : AbstractValidator<MovieDTO>
    {
        public MovieValidator()
        {
            RuleFor(task => task.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(task => task.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(task => task.Year)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage("Invalid year");
            RuleFor(task => task.TrailerLink)
                .NotNull()
                .NotEmpty()
                .Must(ValidationMethods.IsUrl);
            RuleFor(task => task.ThumbnailLink)
                .NotNull()
                .NotEmpty()
                .Must(ValidationMethods.IsUrl);
            RuleFor(task => task.TrailerLink)
                .NotNull()
                .NotEmpty()
                .Must(ValidationMethods.IsUrl);
        }
    }
}
