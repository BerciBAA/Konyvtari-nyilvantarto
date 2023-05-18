using FluentValidation;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Helpers;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Validators.LibraryMemberValidators
{
    public class UpdateLibraryMemberRequestValidator : AbstractValidator<UpdateLibraryMemberRequest>
    {
        internal const string IdErrorMessage = "Invalid Guid ID.";

        public UpdateLibraryMemberRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(IdErrorMessage);

            RuleFor(x => x.Name)
                .Must(ValidatorHelper.IsNameValid)
                .WithMessage(ValidatorHelper.InvalidStringErrorMessage);

            RuleFor(x => x.Address)
                .Must(ValidatorHelper.IsAddressValid)
                .WithMessage(ValidatorHelper.InvalidStringErrorMessage);

            RuleFor(x => x.DateOfBirth.Year)
                .LessThanOrEqualTo(DateTime.UtcNow.Year - ValidatorHelper.LowestAllowedAge)
                .WithMessage(ValidatorHelper.MemberMustBeOlderThanLowestAllowedAge());
        }
    }
}
