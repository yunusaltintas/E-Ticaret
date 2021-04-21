using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Data.ViewModels;

namespace Ticaret.Service
{
    public interface ICategoryService
    {
        Task<ReturnParameterModel<List<Category>>> GetAllCategoryAsync();
        Task<ReturnParameterModel<List<Category>>> GetAllCategoryOrderLetterAsync();
        Task<ReturnModel> AddCategory(AddCategoryViewModel AddCategoryViewModel);
        Task<ReturnParameterModel<Category>> GetCategoryByIdAsync(int id);
        Task<ReturnParameterModel<Category>> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        Task<ReturnModel> DeleteCategoryAsync(int id);
    }
}
