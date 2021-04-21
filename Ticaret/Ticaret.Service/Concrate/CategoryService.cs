using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Data.ViewModels;
using Ticaret.Repository;

namespace Ticaret.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository baseRepository)
        {
            _categoryRepository = baseRepository;
        }

        public async Task<ReturnModel> AddCategory(AddCategoryViewModel AddCategoryViewModel)
        {
            var result = new Category
            {
                CategoryName = AddCategoryViewModel.CategoryName
            };

           var AddedModel=await _categoryRepository.TAddAsync(result);
            if (AddedModel.Id==0)
            {
                return new ReturnModel("hata var");
            }
            return new ReturnModel();
        }

        public async Task<ReturnModel> DeleteCategoryAsync(int id)
        {
           var result= await _categoryRepository.TRemoveAsync(id);
            if (result==false)
            {
                return new ReturnModel("hata var");
            }
            return new ReturnModel();
        }

        public async Task<ReturnParameterModel<List<Category>>> GetAllCategoryAsync()
        {
           var result= await _categoryRepository.TGetAllAsync();

            if (result==null)
            {
                return new ReturnParameterModel<List<Category>>("hata var");
            }
            return new ReturnParameterModel<List<Category>>(result);
        }

        public async Task<ReturnParameterModel<List<Category>>> GetAllCategoryOrderLetterAsync()
        {
            var result = await _categoryRepository.TGetAllCategoryOrderLetter();

            if (result == null)
            {
                return new ReturnParameterModel<List<Category>>("hata var");
            }
            return new ReturnParameterModel<List<Category>>(result);
        }

        public async Task<ReturnParameterModel<Category>> GetCategoryByIdAsync(int id)
        {
            var result=await _categoryRepository.TGetByIdAsync(id);
            if (result==null)
            {
                return new ReturnParameterModel<Category>("hata var");
            }
            return new ReturnParameterModel<Category>(result);
        }

        public async Task<ReturnParameterModel<Category>> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
           var WillUpdate=await _categoryRepository.TGetByIdAsync(updateCategoryViewModel.Id);

            if (WillUpdate.Id==0)
            {
                return new ReturnParameterModel<Category>("hata var");
            }
            WillUpdate.CategoryName = updateCategoryViewModel.CategoryName;

            await _categoryRepository.TUpdateAsync(WillUpdate);
            return new ReturnParameterModel<Category>(WillUpdate);
        }
    }
}
