using FluentValidation;
using FurnitureShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleForEach(x => x.Translations)
            .SetValidator(new ProductTranslationValidator());

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price 0-dan böyük olmalıdır");

        RuleFor(x => x.PriceExtra)
            .GreaterThan(0)
            .When(x => x.PriceExtra.HasValue)
            .WithMessage("PriceExtra 0-dan böyük olmalıdır");

        RuleFor(x => x.Label)
            .NotEmpty().WithMessage("Label boş ola bilməz")
            .MaximumLength(100);

        RuleFor(x => x.Material)
            .NotEmpty().WithMessage("Material boş ola bilməz")
            .MaximumLength(100);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId düzgün deyil");

        RuleFor(x => x.Colors)
            .NotNull().WithMessage("Colors null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 rəng olmalıdır");

        RuleForEach(x => x.Colors)
            .NotEmpty().WithMessage("Color boş ola bilməz");

        RuleFor(x => x.Images)
            .NotNull().WithMessage("Images null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 şəkil olmalıdır");

        RuleForEach(x => x.Images)
            .NotEmpty().WithMessage("Image boş ola bilməz");

        RuleFor(x => x.Translations)
            .NotNull().WithMessage("Translations null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 translation olmalıdır");
    }
}