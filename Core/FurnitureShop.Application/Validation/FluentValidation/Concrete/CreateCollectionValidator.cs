using FluentValidation;
using FurnitureShop.Application.Dtos.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;


public class CreateCollectionValidator : AbstractValidator<CreateCollectionDto>
{
    public CreateCollectionValidator()
    {
        RuleFor(x => x.CoverImageUrl)
            .NotEmpty().WithMessage("Cover image boş ola bilməz");

        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("Total price 0-dan böyük olmalıdır");

        RuleFor(x => x.DiscountPrice)
            .LessThan(x => x.TotalPrice)
            .When(x => x.DiscountPrice.HasValue)
            .WithMessage("Discount price total price-dan kiçik olmalıdır");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category düzgün deyil");

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ProductIds)
            .NotNull().WithMessage("ProductIds null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 product olmalıdır");

        RuleFor(x => x.Translations)
            .NotNull().WithMessage("Translations null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 translation olmalıdır");
    }
}
