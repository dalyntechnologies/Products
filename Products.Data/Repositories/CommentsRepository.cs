using Microsoft.EntityFrameworkCore;
using Products.Data.Repositories.Interfaces;
using Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Repositories
{
    public class CommentsRepository : Repository<Product>, ICommentsRepository
    {
        private ProductDbContext AppContext => (ProductDbContext)_context;
        public CommentsRepository(DbContext context) : base(context)
        {
        }

        public void AddComment(Comments entity)
        {
            AppContext.Comments.Add(entity);
        }

        public async Task<IEnumerable<Comments>> GetCommentsByProduct(int productId)
        {
            IQueryable<Comments> query = AppContext.Comments.Where(a=>a.ProductId==productId);
            var byProductIdQuery = await query.ToListAsync();
            return byProductIdQuery.ToList();
        }
    }
    }
