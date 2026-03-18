using FluentValidation;
using FurnitureShop.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Validation.FluentValidation.Concrete;


public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Order type düzgün deyil");

        RuleFor(x => x.DeliveryAddress)
            .NotEmpty().When(x => x.Type.ToString() == "Delivery")
            .WithMessage("Delivery address tələb olunur");

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Items null ola bilməz")
            .Must(x => x.Count > 0).WithMessage("Ən azı 1 item olmalıdır");

        RuleFor(x => x.GuestName)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.GuestEmail))
            .WithMessage("GuestName tələb olunur");

        RuleFor(x => x.GuestPhone)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.GuestEmail))
            .WithMessage("GuestPhone tələb olunur");

        RuleFor(x => x.GuestEmail)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.GuestEmail))
            .WithMessage("Email formatı yanlışdır");
    }
}
