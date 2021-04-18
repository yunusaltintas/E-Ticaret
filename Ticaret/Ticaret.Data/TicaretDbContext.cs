using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ticaret.Data.EntityTypeBuilder;

namespace Ticaret.Data.Entities
{
    public class TicaretDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public TicaretDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryTypeBuilder())
                        .ApplyConfiguration(new ProductTypeBuilder());
                        


            base.OnModelCreating(modelBuilder);
        }


    }
}
