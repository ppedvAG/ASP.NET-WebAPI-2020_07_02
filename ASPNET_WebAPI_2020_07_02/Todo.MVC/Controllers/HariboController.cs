using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.MVC.Data;

namespace Todo.MVC.Controllers
{
    public class HariboController : Controller
    {
        public HariboController(BlogDbContext ctx)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
