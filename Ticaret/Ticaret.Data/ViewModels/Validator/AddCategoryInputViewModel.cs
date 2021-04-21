using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels.Validator
{
    public class AddCategoryInputViewModel: AbstractValidator<AddCategoryViewModel>
    {
        public AddCategoryInputViewModel()
        {
            RuleFor(o => o.CategoryName).NotEmpty().NotNull();
        }
    }
}
