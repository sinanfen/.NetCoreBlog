using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="C# programlama"},
                new BlogModel{Id=2,BlogName="Java programlama"},
                new BlogModel{Id=3,BlogName="Python programlama"},
                new BlogModel{Id=4,BlogName="JavaScript programlama"},
            };

            return blogModels;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTittleList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    var adEkle = DateTime.Now.Ticks;
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma_" + adEkle + ".xlsx");
                }
            }
        }

        public List<BlogModelDynamic> BlogTittleList()
        {
            List<BlogModelDynamic> blogModelDynamics = new List<BlogModelDynamic>();
            using (var c = new Context())
            {
                blogModelDynamics = c.Blogs.Select(x => new BlogModelDynamic
                {
                    Id = x.BlogID,
                    BlogName = x.BlogTittle
                }).ToList();
            }

            return blogModelDynamics;
        }

        public IActionResult BlogTittleListExcel()
        {
            return View();
        }
    }
}
