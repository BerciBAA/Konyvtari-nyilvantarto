using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Validators
{
    public class CreateLibraryMemberRequestValidator : AbstractValidator<CreateLibraryMemberRequest>
    {
        internal const string InvalidStringErrorMessage = "{PropertyName} is invalid.";
        internal const int LowestAllowedAge = 12;

        internal IReadOnlyList<string> ForbiddenCharacters = new List<string>() { "!", "?", "_", "-", ":", ";", "#" };

        public CreateLibraryMemberRequestValidator()
        {
            RuleFor(x => x.Name)
                .Must(ValidateName)
                .WithMessage(InvalidStringErrorMessage);

            RuleFor(x => x.Address)
                .Must(ValidateAddress)
                .WithMessage(InvalidStringErrorMessage);

            RuleFor(x => x.DateOfBirth.Year)
                .LessThanOrEqualTo(DateTime.UtcNow.Year - LowestAllowedAge)
                .WithMessage(MemberMustBeOlderThanLowestAllowedAge());
        }

        private bool ValidateAddress(string address) => !string.IsNullOrWhiteSpace(address);

        private bool ValidateName(string name)
        {
            bool hasNameForbiddenCharacter = false;
            foreach (var character in ForbiddenCharacters)
            {
                if (name.Contains(character))
                {
                    hasNameForbiddenCharacter = true;
                    break;
                }
            }

            return !string.IsNullOrWhiteSpace(name) && !hasNameForbiddenCharacter;
        }

        private string MemberMustBeOlderThanLowestAllowedAge() => $"Member must be older than {LowestAllowedAge}";
    }
}
