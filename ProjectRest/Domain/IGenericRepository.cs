using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectRest.Domain
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entitys);
        void Remove(T entity);
        void RemoveRang(IEnumerable<T> entitys);
    }
}
