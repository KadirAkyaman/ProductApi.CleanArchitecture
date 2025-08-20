using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using KayraExport.Api.DTOs;

namespace KayraExport.Api.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(cp => cp.Name)
                .NotEmpty().WithMessage("The product name cannot be blank.")
                .MaximumLength(100).WithMessage("The product name cannot be longer than 100 characters.");

            RuleFor(cp => cp.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be less than 0.");

            RuleFor(cp => cp.Price)
                .GreaterThan(0).WithMessage("The price must be greater than 0.");
        }
    }
}