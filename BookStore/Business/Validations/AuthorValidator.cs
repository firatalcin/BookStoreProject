using Core.Model;
using FluentValidation;

namespace Business.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public string NotEmptyProperty { get; } = "{PropertyName} boş geçilemez";

        public AuthorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
        }
    }
}