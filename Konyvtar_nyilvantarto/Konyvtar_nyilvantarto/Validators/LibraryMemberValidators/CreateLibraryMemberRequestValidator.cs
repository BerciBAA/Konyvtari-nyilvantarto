using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Helpers;

namespace Konyvtar_nyilvantarto.Validators.LibraryMemberValidators
{
    public class CreateLibraryMemberRequestValidator : AbstractValidator<CreateLibraryMemberRequest>
    {
        public CreateLibraryMemberRequestValidator()
        {
            RuleFor(x => x.Name)
                .Must(ValidatorHelper.IsNameValid)
                .WithMessage(ValidatorHelper.InvalidStringErrorMessage);

            RuleFor(x => x.Address)
                .Must(ValidatorHelper.IsAddressValid)
                .WithMessage(ValidatorHelper.InvalidStringErrorMessage);

            RuleFor(x => x.DateOfBirth)
                .Must(x => x.Year <= DateTime.UtcNow.Year - ValidatorHelper.LowestAllowedAge)
                .WithMessage(ValidatorHelper.MemberMustBeOlderThanLowestAllowedAge());
        }
    }
}