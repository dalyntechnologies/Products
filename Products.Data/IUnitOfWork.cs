using Products.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Data
{
    public interface IUnitOfWork
    {

        IProductRepository Product { get; }
        ICommentsRepository Comments { get; }
       

        int SaveChanges();
    }
}
