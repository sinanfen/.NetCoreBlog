using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox()
        {
            int id = 2;
            var values = message2Manager.GetInboxListByWriter(id);
            return View(values);            
        }

        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.TGetById(id);
            return View(value);
        }
    }
}
