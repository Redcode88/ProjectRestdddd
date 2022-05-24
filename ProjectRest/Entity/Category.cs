﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRest.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product>  Products { get; set; }
    }
}
