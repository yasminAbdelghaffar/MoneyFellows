using Application.Commands.Orders;
using FluentValidation;

namespace Application.Validators
{
    public class OrderValidator : AbstractValidator<AddOrderCommand>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Order.DeliveryAddress)
                .NotEmpty().WithMessage("Delivery Address is required.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Delivery Address must contain only alphanumeric characters and spaces.");

            RuleFor(x => x.Order.DeliveryTime)
                .NotEmpty().WithMessage("Delivery time is required.");

            RuleFor(x => x.Order.TotalCost).NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Order.User)
                .NotEmpty().WithMessage("User is required.");
        }
    }

}
