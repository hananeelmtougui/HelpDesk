using Api.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HelpDeskContext _helpDeskContext;
        public GenericRepository(HelpDeskContext helpDeskContext)
        {
            this._helpDeskContext = helpDeskContext;
        }

        public void Add(T entity)
        {
            _helpDeskContext.Set<T>().Add(entity);
        }


        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _helpDeskContext.Set<T>().Where(expression).ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
           
           return _helpDeskContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            //throw new NotImplementedException();
           return  _helpDeskContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
          _helpDeskContext.Set<T>().Remove(entity);
        
        }

        public void Update(T entity)
        {
            _helpDeskContext.Set<T>().Update(entity);
        }
    }
}
