using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using KayraExport.Api.DTOs;

namespace KayraExport.Api.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(up => up.Name)
                .NotEmpty().WithMessage("The product name cannot be blank.")
                .MaximumLength(100).WithMessage("The product name cannot be longer than 100 characters.");

            RuleFor(up => up.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be less than 0.");

            RuleFor(up => up.Price)
                .GreaterThan(0).WithMessage("The price must be greater than 0.");
        }
    }
}