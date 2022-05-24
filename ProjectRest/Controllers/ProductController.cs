using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRest.DB;
using ProjectRest.Repositories;

namespace ProjectRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopDataContext _context;
        public ProductController(ShopDataContext context)   
        {
            _context = context;
        }

        [Route("GetAllProduct")]
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            ProductRepository pr = new ProductRepository(_context);
            var data = pr.GetAll();
            if (data == null)
            {
                return BadRequest("There's No data on Product Table");
            }
            return Ok(data);

        }





    }
}