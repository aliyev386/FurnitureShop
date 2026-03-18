using FluentValidation;
using FurnitureShop.Application.Dtos.FurnitureCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;


public class FurnitureCategoryTranslationValidator : AbstractValidator<FurnitureCategoryTranslationDto>
{
    public FurnitureCategoryTranslationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name boş ola bilməz");

        RuleFor(x => x.Language)
            .NotEmpty().WithMessage("Language code boş ola bilməz")
            .MaximumLength(5);
    }
}
