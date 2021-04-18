using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;

namespace Ticaret.Service
{
    public interface ICategoryService
    {
        Task<ReturnParameterModel<List<Category>>> GetAllCategoryAsync();
    }
}
