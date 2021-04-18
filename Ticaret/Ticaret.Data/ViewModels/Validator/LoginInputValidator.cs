using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels.Validator
{
   public class LoginInputValidator:AbstractValidator<UserLoginViewModel>
    {
        public LoginInputValidator()
        {
            RuleFor(o => o.UserName).NotEmpty().NotNull().WithMessage("hata var");
            RuleFor(o => o.Password).NotEmpty().NotNull();
        }
    }
}
