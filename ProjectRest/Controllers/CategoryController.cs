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
    public class CategoryController : ControllerBase
    {
        private readonly ShopDataContext _context;
       
        public CategoryController(ShopDataContext context, CategoryRepository _c)
        {
            _context = context;
        }
      [Route("GetAllCategory")]
      [HttpGet]
      public IActionResult GetAllCategory()
      {
            CategoryRepository c = new CategoryRepository(_context);
            var data = c.GetAll();
            if (data != null)
            {
                return Ok(data.ToList());
            }
            return BadRequest("Data Not Found");
      }
        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(Category module)
        {
            CategoryRepository c = new CategoryRepository(_context);
            if ( ModelState.IsValid)
            {
                c.Add(module);
                return Ok(new string("Category Save Done"));
            }
            return BadRequest("You shoud add all necessery Fileds");
        }

        [Route("GetCategoryById")]
        [HttpPost]
        public IActionResult GetCategoryById([FromBody] int Id)
        {
            CategoryRepository c = new CategoryRepository(_context);

            var data = c.GetById(Id);
            if (data == null)
            {
                return BadRequest($"theres No data depended with this id: {Id}");
            }
            return Ok(data);
        }

        [Route("DeleteCategory")]
        [HttpPost]
        public IActionResult DeleteCategory([FromBody] int? Id)
        {
            var Record = _context.Categories.Where(s => s.Id == Id).FirstOrDefault();
            CategoryRepository c = new CategoryRepository(_context);
            if (Record == null)
            {
                return BadRequest($"There's No Data belong this Id : {Id}");
            }
            c.Remove(Record);
            return Ok();

        }



    }
}