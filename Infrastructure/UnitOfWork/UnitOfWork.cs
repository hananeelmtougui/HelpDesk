using Api.Models;
using Infrastructure.Interfaces;
using Infrastructure.TypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    
    public class UnitOfWork : IUnitOfWork
    {

        private readonly HelpDeskContext _helpDeskContext;
        public UnitOfWork(HelpDeskContext helpDeskContext)
        {
           
            _helpDeskContext = helpDeskContext;
            Product = new ProductRepository(this._helpDeskContext);
            
            
        }

        public IProductRepository Product { get; private set; }

       
        public void Dispose()
        {
            _helpDeskContext.Dispose();
        }

        public int save()
        {
            return _helpDeskContext.SaveChanges();
        }
    }
}
