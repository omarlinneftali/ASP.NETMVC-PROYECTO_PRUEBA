﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace StoreHouse.Models
{
    public class Category
    {

        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }





    }
}

