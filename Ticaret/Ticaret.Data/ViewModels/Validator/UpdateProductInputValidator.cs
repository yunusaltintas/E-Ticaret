using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels.Validator
{
    public class UpdateProductInputValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductInputValidator()
        {
            RuleFor(o => o.ProductName).NotEmpty().NotNull();
            RuleFor(o => o.Price).NotEmpty().NotNull().GreaterThan(0);
                //RuleFor(o => o.Category).NotEmpty().NotNull();

        }

    }
}
