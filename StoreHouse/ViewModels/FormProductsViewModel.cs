using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreHouse.Models;

namespace StoreHouse.ViewModel
{
    public class FormProductsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories{ get; set; }
    }
}

