using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ticaret.Data.Entities;

namespace Ticaret.Data.EntityTypeBuilder
{
    public class CategoryTypeBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(i => i.Products).WithOne(i => i.Categories).HasForeignKey(i => i.CategoryId);

            builder.Property(p => p.CategoryName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(150);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

        }
    }
}
