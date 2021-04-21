using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        private readonly TicaretDbContext _context;
        private readonly DbSet<Category> _dbCategory;
        private readonly DbSet<Product> _dbProduct;

        public CategoryRepository(TicaretDbContext context):base(context)
        {
            _context = context;
            _dbCategory = _context.Set<Category>();
            _dbProduct = _context.Set<Product>();
        }
    

        public async Task<List<Category>> TGetAllCategoryOrderLetter()
        {
            return await _dbCategory.OrderBy(x => x.CategoryName).ToListAsync();
        }

    }
}
