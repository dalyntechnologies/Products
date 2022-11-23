using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Products.Entities;
using Products.Data.Configurations;

namespace Products.Data
{
    public class ProductDbContext : DbContext
    {
        


        public DbSet<Product> Product { get; set; }

        public DbSet<Comments> Comments { get; set; }

     
    
        //public DbSet<Car> Car { get; set; }
        public ProductDbContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CommentsConfiguration());
            
        }


        public override int SaveChanges()
        {
       
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
           
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
           
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        
    }
}
