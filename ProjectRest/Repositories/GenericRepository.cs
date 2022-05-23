using ProjectRest.DB;
using ProjectRest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectRest.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShopDataContext _context;
        public GenericRepository(ShopDataContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entitys)
        {
            _context.Set<T>().AddRange(entitys);
        }

        

        public IEnumerable<T> GetAll()
        {
          return  _context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRang(IEnumerable<T> entitys)
        {
            _context.Set<T>().RemoveRange(entitys);
        }
    }
}
