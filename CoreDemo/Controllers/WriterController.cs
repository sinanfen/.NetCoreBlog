using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
            string id = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value;
            ViewBag.id = id;
            ViewBag.mail = mail;
            ViewBag.Name = writerManager.TGetByFilter(x => x.WriterMail == mail).WriterName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        //[HttpGet]
        //public IActionResult EditWriterProfile()
        //{
        //    Context c = new Context();
        //    var userName = User.Identity.Name;
        //    var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
        //    var id = c.Users.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
        //    var values = userManager.TGetById(id);
        //    return View(values);

        //}
        [HttpGet]
        public async Task<IActionResult> EditWriterProfile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel();
            userUpdateViewModel.mail = values.Email;
            userUpdateViewModel.username = values.UserName;
            userUpdateViewModel.namesurname = values.NameSurname;
            userUpdateViewModel.imageurl = values.ImageUrl;
            return View(userUpdateViewModel);
        }

        //[HttpPost]
        //public IActionResult EditWriterProfile(Writer p)
        //{
        //    WriterValidator writerValidator = new WriterValidator();
        //    ValidationResult results = writerValidator.Validate(p);
        //    if (results.IsValid)
        //    {
        //        writerManager.TUpdate(p);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> EditWriterProfile(UserUpdateViewModel userUpdateViewModel)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = userUpdateViewModel.mail;
            values.UserName = userUpdateViewModel.username;
            values.NameSurname = userUpdateViewModel.namesurname;
            values.ImageUrl = userUpdateViewModel.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userUpdateViewModel.password);
            var result = await _userManager.UpdateAsync(values);
            //WriterValidator writerValidator = new WriterValidator();
            //ValidationResult results = writerValidator.Validate(p);
            return RedirectToAction("Index", "Dashboard");

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer writer = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterMail = p.WriterMail;
            writer.WriterName = p.WriterName;
            writer.WriterPassword = p.WriterPassword;
            writer.WriterPasswordConfirm = p.WriterPasswordConfirm;
            writer.WriterStatus = true;
            writer.WriterAbout = p.WriterAbout;
            writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }

        //public IActionResult LogOut()
        //{

        //}
    }
}
