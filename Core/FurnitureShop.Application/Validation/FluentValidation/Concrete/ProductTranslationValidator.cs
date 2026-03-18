using FluentValidation;
using FurnitureShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;


public class ProductTranslationValidator : AbstractValidator<ProductTranslationDto>
{
    public ProductTranslationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name boş ola bilməz");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description boş ola bilməz");

        RuleFor(x => x.Language)
            .NotEmpty().WithMessage("Language code boş ola bilməz")
            .MaximumLength(5);
    }
}