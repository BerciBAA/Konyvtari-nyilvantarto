using FluentValidation.TestHelper;
using Konyvtar_nyilvantarto.Validators;
using LibaryRegister.Contracts.Book;

namespace BookUnitTest
{
    public class BookValidatorTests
    {
        private readonly BookRequestValidator _validator;

        public BookValidatorTests()
        {
            _validator = new BookRequestValidator();
        }
        [Theory]
        [InlineData("title")]
        [InlineData("Darcula")]
        [InlineData("title2")]
        [InlineData("title3")]
        public void ValidTitle_ShouldNotThrowException(string testValue)
        {
            var createBookRequest = new BookRequest {
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
            var createBookRequest = new BookRequest
            {
                Title = testValue

            };
            var result = _validator.TestValidate(createBookRequest);
            result.ShouldHaveValidationErrorFor(x => x.Title).WithErrorMessage(BookRequestValidator.NotNullEmptyWhiteMessage.Replace("{PropertyName}", nameof(BookRequest.Title)));

        }
    }
}