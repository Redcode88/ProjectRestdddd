using ProjectRest.Domain;
using ProjectRest.DTO;
using ProjectRest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRest.Repositories
{
    public interface IProduct: IGenericRepository<Product>
    {
        //to show Query using join on link viewmodel
        IQueryable<ProductVM> GetProducts();
    }
}
