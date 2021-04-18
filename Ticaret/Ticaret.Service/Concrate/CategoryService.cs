using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Repository;

namespace Ticaret.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository<Category> _categoryRepository;

        public CategoryService(ICategoryRepository<Category> baseRepository)
        {
            _categoryRepository = baseRepository;
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
    }
}
