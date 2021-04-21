using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<List<Category>> TGetAllCategoryOrderLetter();
    }
}
