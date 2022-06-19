using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class GenreValidator : AbstractValidator<GenreAddDto>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}