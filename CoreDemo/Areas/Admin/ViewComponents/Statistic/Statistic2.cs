using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.value2 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTittle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
