using System;
using System.Collections.Generic;
using System.Text;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(TicaretDbContext context):base(context)
        {

        }

    }
}
