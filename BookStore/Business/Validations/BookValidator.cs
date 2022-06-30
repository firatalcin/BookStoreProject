using Core.Model;
using FluentValidation;

namespace Business.Validations
{
    public class BookValidator : AbstractValidator<Book>
    {
        public string NotEmptyProperty { get; } = "{PropertyName} boş geçilemez";

        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.PageCount).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
        }
    }
}