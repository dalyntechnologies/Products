using Microsoft.EntityFrameworkCore;
using Products.Data.Repositories.Interfaces;
using Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Products.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ProductDbContext AppContext => (ProductDbContext)_context;
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public void AddEntity(Product entity)
        {
            AppContext.Product.Add(entity);
        }

        public void UpdateEntity(Product entity)
        {
            AppContext.Product.Update(entity);
        }

        public void DeleteEntity(Product entity)
        {
           AppContext.Product.Remove(entity);
        }

        public async Task<IEnumerable<Product>> GetEntities()
        {
            return await AppContext.Product.Include(a=>a.Comments).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetEntitiesAsync(int page, int pageSize)
        {
            IQueryable<Product> query = AppContext.Product;

            if (page != -1)
                query = query.Skip((page - 1) * pageSize);

            if (pageSize != -1)
                query = query.Take(pageSize);

            var finalQuery = await query.ToListAsync();


            return finalQuery;
        }

        public Task<IEnumerable<Product>> GetEntitiesAsync(int page, int pageSize, string filter)
        {
            throw new NotImplementedException();//to implement on filter,sort,search
        }

        public async Task<Product> GetEntities(int id)
        {
           return await AppContext.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await AppContext.Product.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> HasProductByName(string name)
        {
            return await AppContext.Product.AnyAsync(x => x.Name == name);
        }

        public async Task<int> GetTotalProducts()
        {
            return await AppContext.Product.CountAsync();
        }
    }
    
    
}
