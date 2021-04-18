using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ticaret.Data.Entities;

namespace Ticaret.Data.EntityTypeBuilder
{
    public class ProductTypeBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasOne(p => p.Categories).WithMany(p => p.Products).HasForeignKey(p=>p.CategoryId);

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(150);
            builder.Property(p => p.Price)
                .IsRequired()
                 .HasColumnType("int")
                .HasMaxLength(150);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
        }
    }
}
