﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _006WebAPI_WithEF_AND_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}