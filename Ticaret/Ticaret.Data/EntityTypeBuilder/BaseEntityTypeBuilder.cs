using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ticaret.Data.Entities;

namespace Ticaret.Data.EntityTypeBuilder
{
    public class BaseEntityTypeBuilder<T> : IEntityTypeConfiguration<BaseEntity> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

        }
    }
}
