using ProjectRest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRest.DTO
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
