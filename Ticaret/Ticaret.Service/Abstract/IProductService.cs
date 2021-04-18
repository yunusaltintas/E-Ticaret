using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Data.ViewModels;

namespace Ticaret.Service
{
    public interface IProductService
    {
        Task<ReturnParameterModel<List<Product>>> GetAllProductAsync();
        Task<ReturnParameterModel<Product>> GetProductByIdAsync(int id);
        Task<ReturnParameterModel<List<Product>>> GetProductWithCategory();
        Task<ReturnModel> AddProduct(AddProductViewModel addProductViewModel);

        Task<ReturnParameterModel<Product>> UpdateProduct(UpdateProductViewModel updateProductViewModel);

        Task<ReturnModel> DeleteProductAsync(int id);

    }
}
