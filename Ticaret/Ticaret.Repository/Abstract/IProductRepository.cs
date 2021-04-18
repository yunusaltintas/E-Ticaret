using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public interface IProductRepository:ICategoryRepository<Product>
    {
        Task<Category> GetCategoryById(int id);
    }
}
