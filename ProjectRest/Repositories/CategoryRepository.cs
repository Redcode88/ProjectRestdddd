using Microsoft.EntityFrameworkCore;
using ProjectRest.DB;
using ProjectRest.Domain.CategoryRepo;
using ProjectRest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectRest.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly ShopDataContext _context;
        public CategoryRepository(ShopDataContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Category> entitys)
        {
            _context.AddRange(entitys);
            _context.SaveChanges();
        }

       

        public IEnumerable<Category> GetAll(Category module)
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            
            return _context.Categories.Include(p => p.Products).ToList();
        }

        public Category GetById(int Id)
        {
            return _context.Categories.Find(Id);
        }

        public void Remove(Category entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRang(IEnumerable<Category> entitys)
        {
            _context.RemoveRange(entitys);
            _context.SaveChanges();
        }
    }
}
