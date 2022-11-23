using Microsoft.EntityFrameworkCore;
using Products.Data.Repositories;
using Products.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbContext _context;

        private IProductRepository _product;
        private ICommentsRepository _comments;
      
        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_context);
                return _product;
            }
        }
        public ICommentsRepository Comments
        {
            get
            {
                if (_comments == null)
                    _comments = new CommentsRepository(_context);
                return _comments;
            }
        }       
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
