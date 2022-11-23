using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Products.Data.Configurations
{


    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder
           .HasMany(s => s.Comments)
           .WithOne().HasForeignKey(s => s.ProductId)
           .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
