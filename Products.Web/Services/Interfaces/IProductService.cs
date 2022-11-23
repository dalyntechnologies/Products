using Products.Web.Models;
using Products.Web.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Web.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetProductsAsync();
        public Task<ProductResponse> GetProductAsync(int id);
        public Task<bool> DeleteProductAsync(int id);
        public Task<(bool,string)> AddProductAsync(ProductViewModel product);
        public Task<(bool, string)> UpdateProductAsync(ProductViewModel product);
    }
}
