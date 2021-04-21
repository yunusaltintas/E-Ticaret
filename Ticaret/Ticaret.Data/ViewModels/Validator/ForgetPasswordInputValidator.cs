using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels.Validator
{
    public class ForgetPasswordInputValidator:AbstractValidator<ForgetPasswordViewModel>
    {
        public ForgetPasswordInputValidator()
        {
            RuleFor(o => o.Email).EmailAddress().NotEmpty().NotNull();

        }
    }
}
