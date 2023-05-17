namespace Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Helpers
{
    public static class ValidatorHelper
    {
        public static string InvalidStringErrorMessage = "{PropertyName} is invalid.";
        public static int LowestAllowedAge = 12;

        public static IReadOnlyList<string> ForbiddenCharacters = new List<string>() { "!", "?", "_", "-", ":", ";", "#" };

        public static bool IsAddressValid(string address) => !string.IsNullOrWhiteSpace(address);

        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            bool hasNameForbiddenCharacter = false;
            foreach (var character in ForbiddenCharacters)
            {
                if (name.Contains(character))
                {
                    hasNameForbiddenCharacter = true;
                    break;
                }
            }

            return !hasNameForbiddenCharacter;
        }

        public static string MemberMustBeOlderThanLowestAllowedAge() => $"Member must be older than {LowestAllowedAge}";
    }
}
