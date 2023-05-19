using FluentValidation;
using LibaryRegister.Contracts.Book;

namespace Konyvtar_nyilvantarto.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public static string NotNullEmptyWhiteMessage = "{PropertyName} is null empty or white space.";
        internal const string LessThanOrEqualToMessage = "{PropertyName} is higher than actualy year.";
        public BookRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(NotNullEmptyWhiteMessage);
            RuleFor(x => x.YearOfPublication).LessThanOrEqualTo(DateTime.UtcNow.Year).WithMessage(LessThanOrEqualToMessage);
            
        }
    }
}
