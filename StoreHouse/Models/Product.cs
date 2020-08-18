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
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        [Display(Name = "Categoria")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}

