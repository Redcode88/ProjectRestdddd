using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjectRest.DB;
using ProjectRest.DTO;
using ProjectRest.Entity;
using System.IO;
namespace ProjectRest.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ShopDataContext _context;
        public ProductRepository(ShopDataContext context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {



            //var folderName = Path.Combine("Resources","Image");
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            
           
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Product> entitys)
        {
            _context.AddRange(entitys);
            _context.SaveChanges();

        }

        public IEnumerable<Product> GetAll()
        {
            var res = from p in _context.Products
                      join c in _context.Categories on p.CategoryId equals c.CategoryId
                      select new Product
                      {
                          ProductId = p.ProductId,
                          ProductName = p.ProductName,
                          Price = p.Price,
                          Unit = p.Unit,
                          CategoryId = c.CategoryId,
                          Category = new Category
                          {
                              CategoryId = c.CategoryId,
                              Name = c.Name,
                          }
                      };
            return res.ToList();


            //var res = _context.Products.FromSql("SELECT p.ProductId,p.ProductName,p.Price,p.Unit,p.CategoryId  From Products p ").AsNoTracking().ToList();
            //return res;
        }

        public Product GetById(int Id)
        {
             return _context.Products.Find(Id);
        }

        public IQueryable<ProductVM> GetProducts()
        {
            var res = from p in _context.Products
                      join c in _context.Categories on p.CategoryId equals c.CategoryId
                      select new ProductVM
                      {
                          ProductId = p.ProductId,
                          ProductName = p.ProductName,
                          Price = p.Price,
                          Unit = p.Unit,
                          CategoryId = c.CategoryId,
                          Name = c.Name,
                      };
            return res;
        }

        public void Remove(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRang(IEnumerable<Product> entitys)
        {
            _context.Products.RemoveRange(entitys);
            _context.SaveChanges();
        }

        public Product Update(int id,Product entity)
        {
            var Product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
            return Product;
        }
    }
}
