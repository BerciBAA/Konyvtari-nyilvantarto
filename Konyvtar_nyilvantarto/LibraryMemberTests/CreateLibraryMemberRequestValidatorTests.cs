using FluentValidation.TestHelper;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Helpers;

namespace LibraryMemberTests
{
    public class CreateLibraryMemberRequestValidatorTests
    {
        private readonly CreateLibraryMemberRequestValidator _validator;

        public CreateLibraryMemberRequestValidatorTests()
        {
            _validator = new CreateLibraryMemberRequestValidator();
        }

        [Theory]
        [InlineData("Some data")]
        [InlineData("4028 Debrecen Kassai út 26.")]
        [InlineData("4031 Debrecen Határ út 1/A")]
        public void Valid_Address_ShoudNot_Have_Error(string address)
        {
            var request = new CreateLibraryMemberRequest { Address = address };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.Address);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("           ")]
        public void Invalid_Address_Shoud_Have_Error(string address)
        {
            var request = new CreateLibraryMemberRequest { Address = address };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Address).WithErrorMessage(
                ValidatorHelper.InvalidStringErrorMessage.Replace("{PropertyName}", nameof(CreateLibraryMemberRequest.Address)));
        }

        [Theory]
        [InlineData("Some Title")]
        [InlineData("Sprint Elek")]
        [InlineData("Teszt Elek")]
        public void Valid_Name_ShoudNot_Have_Error(string name)
        {
            var request = new CreateLibraryMemberRequest { Name = name };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("           ")]
        [InlineData("Name!")]
        [InlineData("Name?")]
        [InlineData("Firstname-Lastname")]
        [InlineData("Firstname_Lastname")]
        [InlineData("Some:text")]
        [InlineData("#Name#")]
        [InlineData("name;")]
        public void Invalid_Name_Shoud_Have_Error(string name)
        {
            var request = new CreateLibraryMemberRequest { Name = name };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage(
                ValidatorHelper.InvalidStringErrorMessage.Replace("{PropertyName}", nameof(CreateLibraryMemberRequest.Name)));
        }

        [Theory]
        [InlineData("1999. 09. 09.")]
        [InlineData("2005. 05. 05.")]
        [InlineData("1978. 03. 23.")]
        public void Valid_DateOfBirth_ShoudNot_Have_Error(string dateofBirthString)
        {
            var request = new CreateLibraryMemberRequest { DateOfBirth = DateTime.Parse(dateofBirthString) };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Theory]
        [InlineData("2023. 09. 09.")]
        [InlineData("2012. 05. 05.")]
        [InlineData("2099. 03. 23.")]
        public void Invalid_DateOfBirth_Shoud_Have_Error(string dateofBirthString)
        {
            var request = new CreateLibraryMemberRequest { DateOfBirth = DateTime.Parse(dateofBirthString) };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth).WithErrorMessage(ValidatorHelper.MemberMustBeOlderThanLowestAllowedAge());
        }
    }
}