using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRest.DB;
using ProjectRest.Entity;
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
            return new JsonResult(data);

        }

        [Route("GetProductAsList")]
        [HttpGet]
        public IActionResult GetProductAsList()
        {
            ProductRepository pr = new ProductRepository(_context);
            var data = pr.GetProducts();
            if (data == null)
            {
                return BadRequest("There's No data on Product Table");
            }
            return new JsonResult(data);
        }


        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            ProductRepository pr = new ProductRepository(_context);
            if (ModelState.IsValid)
            {
                pr.Add(model);
                return Ok(new string("Product Add Done"));
            }
            return BadRequest("There's Error with data you have enterd");

        }

        [Route("DeleteProduct")]
        [HttpPost]
        public IActionResult DeleteProduct([FromBody] int Id)
        {
            var ProductId = _context.Products.Where(p => p.ProductId == Id).FirstOrDefault();
            ProductRepository pr = new ProductRepository(_context);
            if (Id == 0)
            {
                return BadRequest("you should Select Product To delete");
            }
            pr.Remove(ProductId);
            return Ok(new string("Product Delete Done"));
        }
        //we need update this ....
        [Route("UpdateProduct")]
        [HttpPost]
        public IActionResult UpdateProduct([FromQuery] int id,Product entity)
        {
            ProductRepository pr = new ProductRepository(_context);
            if (id == 0)
            {
                return BadRequest();
            }
            pr.Update(id,entity);
            return Ok(new string("Product Update Done"));
        }



    }
}