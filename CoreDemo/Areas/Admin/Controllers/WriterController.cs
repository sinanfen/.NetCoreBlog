using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writerClasses);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writerClasses.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writerClass)
        {
            writerClasses.Add(writerClass);
            var jsonWriters = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writerClasses.FirstOrDefault(x=>x.Id == id);
            writerClasses.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writerClasses.FirstOrDefault(x=>x.Id == writerClass.Id);
            writer.Name = writerClass.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writerClasses = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ali"
            },
            new WriterClass
            {
                Id=2,
                Name="Veli"
            },
            new WriterClass
            {
                Id=3,
                Name="Buse"
            }
        };
    }
}
