using FluentValidation;

namespace Konyvtar_nyilvantarto.Validators.Common
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        internal const string ErrorMessage = "Invalid Guid ID.";

        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ErrorMessage);
        }
    }
}
