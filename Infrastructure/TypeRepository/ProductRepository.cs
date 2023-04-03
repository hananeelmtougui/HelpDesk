using Api.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TypeRepository
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(HelpDeskContext helpDeskContext) : base(helpDeskContext) { }
       public override IEnumerable<Product> GetAll()
        {
            return _helpDeskContext.Set<Product>().Include(p => p.ProductSerials)
                .Include(p => p.ProductCaracteristics)
                .Include(p => p.IdArrivals);
        }

        
    }
}
