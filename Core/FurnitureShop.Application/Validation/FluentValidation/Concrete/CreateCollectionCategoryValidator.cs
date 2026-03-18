using FluentValidation;
using FurnitureShop.Application.Dtos.CollectionCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;


public class CreateCollectionCategoryValidator : AbstractValidator<CreateCollectionCategoryDto>
{
    public CreateCollectionCategoryValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("ImageUrl boş ola bilməz");

        RuleFor(x => x.Translations)
            .NotNull().WithMessage("Translations null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 translation olmalıdır");

        RuleForEach(x => x.Translations)
            .SetValidator(new CollectionCategoryTranslationValidator());
    }
}
