using FluentValidation;
using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Validators
{
    public class OrderValidator : AbstractValidator<CreateOrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(0).WithMessage("UserId is required");

            RuleFor(x => x.Items.Count())
            .NotEqual(0).WithMessage("Items are required");
        }
    }
}