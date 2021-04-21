using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<List<Product>> TGetProductByCategoryId(int id);
        IQueryable<Product> TQueryOrderLedder();
    }
}
