using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { Categoryname = "Teknoloji", Categorycount = 10 });
            list.Add(new CategoryClass { Categoryname = "Yazılım", Categorycount = 20 });
            list.Add(new CategoryClass { Categoryname = "Spor", Categorycount = 5 });

            return Json(new { jsonlist = list });
        }
    }
}
