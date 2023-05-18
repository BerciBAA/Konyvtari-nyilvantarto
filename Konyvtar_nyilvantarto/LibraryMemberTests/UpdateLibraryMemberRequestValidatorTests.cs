using FluentValidation.TestHelper;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Helpers;

namespace LibraryMemberTests
{
    public class UpdateLibraryMemberRequestValidatorTests
    {
        private readonly UpdateLibraryMemberRequestValidator _validator;

        public UpdateLibraryMemberRequestValidatorTests()
        {
            _validator = new UpdateLibraryMemberRequestValidator();
        }

        [Theory]
        [InlineData("dea130ca-c420-4e85-8c82-60d3cd40044d")]
        [InlineData("7c7e1d50-f4f3-44b8-bec8-312de083c4ce")]
        public void Valid_Id_ShouldNot_Have_Error(string guidString)
        {
            var request = new UpdateLibraryMemberRequest { Id = Guid.Parse(guidString) };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void Invalid_Id_Should_Have_Error()
        {
            var request = new UpdateLibraryMemberRequest { Id = Guid.Empty };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Id).WithErrorMessage(_validator.IdErrorMessage);
        }

        [Theory]
        [InlineData("Some data")]
        [InlineData("4028 Debrecen Kassai út 26.")]
        [InlineData("4031 Debrecen Határ út 1/A")]
        public void Valid_Address_ShouldNot_Have_Error(string address)
        {
            var request = new UpdateLibraryMemberRequest { Address = address };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.Address);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("           ")]
        public void Invalid_Address_Should_Have_Error(string address)
        {
            var request = new UpdateLibraryMemberRequest { Address = address };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Address).WithErrorMessage(
                ValidatorHelper.InvalidStringErrorMessage.Replace("{PropertyName}", nameof(UpdateLibraryMemberRequest.Address)));
        }

        [Theory]
        [InlineData("Some Title")]
        [InlineData("Sprint Elek")]
        [InlineData("Teszt Elek")]
        public void Valid_Name_ShouldNot_Have_Error(string name)
        {
            var request = new UpdateLibraryMemberRequest { Name = name };

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
        public void Invalid_Name_Should_Have_Error(string name)
        {
            var request = new UpdateLibraryMemberRequest { Name = name };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage(
                ValidatorHelper.InvalidStringErrorMessage.Replace("{PropertyName}", nameof(UpdateLibraryMemberRequest.Name)));
        }

        [Theory]
        [InlineData("1999. 09. 09.")]
        [InlineData("2005. 05. 05.")]
        [InlineData("1978. 03. 23.")]
        public void Valid_DateOfBirth_ShouldNot_Have_Error(string dateofBirthString)
        {
            var request = new UpdateLibraryMemberRequest { DateOfBirth = DateTime.Parse(dateofBirthString) };

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Theory]
        [InlineData("2023. 09. 09.")]
        [InlineData("2012. 05. 05.")]
        [InlineData("2099. 03. 23.")]
        public void Invalid_DateOfBirth_Should_Have_Error(string dateofBirthString)
        {
            var request = new UpdateLibraryMemberRequest { DateOfBirth = DateTime.Parse(dateofBirthString) };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth).WithErrorMessage(ValidatorHelper.MemberMustBeOlderThanLowestAllowedAge());
        }
    }
}
