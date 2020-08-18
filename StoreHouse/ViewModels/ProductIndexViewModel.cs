using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreHouse.Models;

namespace StoreHouse.ViewModels
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Category> Categories { get; set; }

    }
}