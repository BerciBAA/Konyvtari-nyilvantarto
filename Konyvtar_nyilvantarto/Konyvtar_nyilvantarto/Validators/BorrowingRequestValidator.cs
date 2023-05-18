using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;

namespace Konyvtar_nyilvantarto.Validators
{
    public class BorrowingRequestValidator : AbstractValidator<BorrowingRequest>
    {
        internal const string LessThan = "{PropertyName} is higher than RetrievalLimitTime.";
        public BorrowingRequestValidator()
        {
            RuleFor(x => x.RentalTime).NotEmpty().LessThan(x => x.RetrievalLimitTime).WithMessage(LessThan);
          
        }
    }
}
