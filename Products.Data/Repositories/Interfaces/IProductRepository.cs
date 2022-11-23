using Products.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddEntity(Product entity);
        void UpdateEntity(Product entity);
        void AddEntity(List<Product> entity);
        void DeleteEntity(Product entity);
        Task<IEnumerable<Product>> GetEntities();
        Task<int> GetTotalProducts();

        Task<Product> GetEntities(int id);
        Task<Product> GetProductByName(string name);
        Task<bool> HasProductByName(string name);
        Task<IEnumerable<Product>> GetEntitiesAsync(int page, int pageSize);
        Task<IEnumerable<Product>> GetEntitiesAsync(int page, int pageSize,string filter);

    }
}
