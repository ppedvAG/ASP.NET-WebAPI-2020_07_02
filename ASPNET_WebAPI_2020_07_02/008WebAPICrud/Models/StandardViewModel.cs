﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _008WebAPICrud.Models
{
    public class StandardViewModel
    {
        public int StandardId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }
}