using FluentValidation;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Models;

namespace Konyvtar_nyilvantarto.Validators.LibraryMemberValidators
{
    public class LibraryMemberQueryParameterValidator : AbstractValidator<QueryParameterValidatorObject>
    {
        public string IntegerErrorMessage = "{PropertyName} is invalid.";

        public LibraryMemberQueryParameterValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage(IntegerErrorMessage);

            RuleFor(x => x.Size)
                .GreaterThan(0)
                .WithMessage(IntegerErrorMessage);
        }
    }
}