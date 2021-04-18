using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;
using Ticaret.Data.ResponseModel;
using Ticaret.Data.ViewModels;
using Ticaret.Repository;

namespace Ticaret.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ReturnModel> AddProduct(AddProductViewModel addProductViewModel)
        {
            var NewProduct = new Product 
            {
                ProductName=addProductViewModel.ProductName,
                Price=addProductViewModel.Price,
                CategoryId=addProductViewModel.CategoryId

            };
            if (addProductViewModel.FilePic != null)
            {
                var path = Path.GetExtension(addProductViewModel.FilePic.FileName);
                var NewPicName = Guid.NewGuid() + path;
                var SourcePic = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + NewPicName);

                var stream = new FileStream(SourcePic, FileMode.Create);
                addProductViewModel.FilePic.CopyTo(stream);

                NewProduct.FilePic = NewPicName;
            }

            var result=await _productRepository.TAddAsync(NewProduct);
            if (result==null)
            {
                return new ReturnModel("hatavar");
            }
            return new ReturnModel();
        }

        public async Task<ReturnModel> DeleteProductAsync(int id)
        {
            //var result = _productRepository.TGetByIdAsync(id);
           bool done= await _productRepository.TRemoveAsync(id);
            if (done==true)
            {
                return new ReturnModel();
            }
            return new ReturnModel("hatavar");
        }

        public async Task<ReturnParameterModel<List<Product>>> GetAllProductAsync()
        {
            var result = await _productRepository.TGetAllAsync();

            if (result == null)
            {
                return new ReturnParameterModel<List<Product>>("hata var");
            }

            return new ReturnParameterModel<List<Product>>(result);
        }

        public async Task<ReturnParameterModel<Product>> GetProductByIdAsync(int id)
        {
            var result = await _productRepository.TGetByIdAsync(id);
            if (result.Id == 0)
            {
                return new ReturnParameterModel<Product>("hata var");
            }
            return new ReturnParameterModel<Product>(result);
        }

        public async Task<ReturnParameterModel<List<Product>>> GetProductWithCategory()
        {
            var result = await _productRepository.TQuery().Include(x => x.Categories).ToListAsync();
            return new ReturnParameterModel<List<Product>>(result);
        }

        public async Task<ReturnParameterModel<Product>> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {

            var güncelenecek = await _productRepository.TGetByIdAsync(updateProductViewModel.Id);

           
            if (updateProductViewModel.FilePic != null)
            {
                var path = Path.GetExtension(updateProductViewModel.FilePic.FileName);
                var NewPicName = Guid.NewGuid() + path;
                var SourcePic = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + NewPicName);

                var stream = new FileStream(SourcePic, FileMode.Create);
                updateProductViewModel.FilePic.CopyTo(stream);

                güncelenecek.FilePic = NewPicName;
            }
            güncelenecek.Id = updateProductViewModel.Id;
            güncelenecek.ProductName = updateProductViewModel.ProductName;
            güncelenecek.Price = updateProductViewModel.Price;

            await _productRepository.TUpdateAsync(güncelenecek);
            return new ReturnParameterModel<Product>(güncelenecek);
        }
    }
}
