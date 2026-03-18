using FluentValidation;
using FurnitureShop.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId düzgün deyil");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity 0-dan böyük olmalıdır");
    }
}