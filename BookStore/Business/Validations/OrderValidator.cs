using Core.Model;
using FluentValidation;

namespace Business.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public string NotEmptyProperty { get; } = "{PropertyName} boş geçilemez";

        public OrderValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.BookId).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
        }
    }
}