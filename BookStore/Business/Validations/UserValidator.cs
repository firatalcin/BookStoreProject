using Core.Model;
using FluentValidation;

namespace Business.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public string NotEmptyProperty { get; } = "{PropertyName} boş geçilemez";

        public UserValidator()
        {
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Uygun olmayan Email formatı").NotEmpty().NotNull().WithMessage(NotEmptyProperty);
        }
    }
}