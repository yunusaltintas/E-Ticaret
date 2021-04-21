using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels.Validator
{
    public class UpdateCategoryInputViewModel : AbstractValidator<UpdateCategoryViewModel>
    {
        public UpdateCategoryInputViewModel()
        {
            RuleFor(o => o.CategoryName).NotEmpty().NotNull();
        }
    }
}
