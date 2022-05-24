using Microsoft.EntityFrameworkCore;
using ProjectRest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRest.DB
{
    public class ShopDataContext :DbContext
    {
        public ShopDataContext(DbContextOptions<ShopDataContext> options) :base(options)
        {

        }
        // tables on DataBase
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //Create Dummy Data When DataBase firstMigration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Mobile"
                },
               new Category {
                   CategoryId = 2,
                   Name = "Clothes"
               }
                
               );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    CategoryId = 1,
                    ProductId = 1,
                    Price = 1150,
                    ProductName = "IPhone x",
                    Unit = "pic",
                },

                  new Product
                  {
                      CategoryId = 2,
                      ProductId = 2,
                      Price = 150,
                      ProductName = "T-shirs Lacoste",
                      Unit = "pic",
                  }

                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
