using Core.DTOs;
using Core.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public string NotEmptyProperty { get; } = "{PropertyName} boş geçilemez";

        public GenreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(NotEmptyProperty);
        }
    }
}