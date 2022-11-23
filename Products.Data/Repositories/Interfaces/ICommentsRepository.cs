using Products.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Repositories.Interfaces
{
    public interface ICommentsRepository
    {
        public void AddComment(Comments entity);
        Task<IEnumerable<Comments>> GetCommentsByProduct(int productId);
    }
}
