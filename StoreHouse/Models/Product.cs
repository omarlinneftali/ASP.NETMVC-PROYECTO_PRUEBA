using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace StoreHouse.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public int Stock { get; set; }
        [Required]

        [Display(Name = "Categoria")]
        public int CategoryID { get; set; }
        [Required]

        public Category Category { get; set; }
    }
}

