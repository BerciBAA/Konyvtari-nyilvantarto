using FluentValidation.TestHelper;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Models;

namespace LibraryMemberTests
{
    public class LibraryMemberQueryParameterValidatorTests
    {
        private readonly LibraryMemberQueryParameterValidator _validator;

        public LibraryMemberQueryParameterValidatorTests()
        {
            _validator = new LibraryMemberQueryParameterValidator();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(999)]
        public void Valid_Page_ShoudNot_Have_Error(int testValue)
        {
            var queryParam = new QueryParameterValidatorObject { Page = testValue };

            var result = _validator.TestValidate(queryParam);

            result.ShouldNotHaveValidationErrorFor(x => x.Page);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-55)]
        [InlineData(-862)]
        [InlineData(-8999)]
        public void Invalid_Page_Shoud_Have_Error(int testValue)
        {
            var queryParam = new QueryParameterValidatorObject { Page = testValue };

            var result = _validator.TestValidate(queryParam);

            result.ShouldHaveValidationErrorFor(x => x.Page).WithErrorMessage(_validator.IntegerErrorMessage.Replace("{PropertyName}", nameof(QueryParameterValidatorObject.Page)));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(999)]
        public void Valid_Size_ShoudNot_Have_Error(int testValue)
        {
            var queryParam = new QueryParameterValidatorObject { Size = testValue };

            var result = _validator.TestValidate(queryParam);

            result.ShouldNotHaveValidationErrorFor(x => x.Size);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-55)]
        [InlineData(-862)]
        [InlineData(-8999)]
        public void Invalid_Size_Shoud_Have_Error(int testValue)
        {
            var queryParam = new QueryParameterValidatorObject { Size = testValue };

            var result = _validator.TestValidate(queryParam);

            result.ShouldHaveValidationErrorFor(x => x.Size).WithErrorMessage(_validator.IntegerErrorMessage.Replace("{PropertyName}", nameof(QueryParameterValidatorObject.Size)));
        }
    }
}
