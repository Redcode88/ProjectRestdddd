using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRest.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string Unit { get; set; }
        [ForeignKey("Id")]
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
