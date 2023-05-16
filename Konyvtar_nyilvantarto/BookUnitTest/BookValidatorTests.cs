using FluentValidation.TestHelper;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Validators;

namespace BookUnitTest
{
    public class BookValidatorTests
    {
        private readonly CreateBookRequestValidator _validator;

        public BookValidatorTests()
        {
            _validator = new CreateBookRequestValidator();
        }
        [Theory]
        [InlineData("title")]
        [InlineData("Darcula")]
        [InlineData("title2")]
        [InlineData("title3")]
        public void ValidTitle_ShouldNotThrowException(string testValue)
        {
            var createBookRequest = new CreateBookRequest {
                Title = testValue

            };
            var result = _validator.TestValidate(createBookRequest);
            result.ShouldNotHaveValidationErrorFor(x=> x.Title);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData(" ")]
        public void InvalidTitle_ShouldThrowException(string testValue)
        {
            var createBookRequest = new CreateBookRequest
            {
                Title = testValue

            };
            var result = _validator.TestValidate(createBookRequest);
            result.ShouldHaveValidationErrorFor(x => x.Title).WithErrorMessage(CreateBookRequestValidator.NotNullEmptyWhiteMessage.Replace("{PropertyName}", nameof(CreateBookRequest.Title)));

        }
    }
}