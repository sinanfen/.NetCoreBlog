using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.value1 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.value2 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.ImageURL).FirstOrDefault();
            ViewBag.value3 = c.Admins.Where(x => x.AdminID == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
