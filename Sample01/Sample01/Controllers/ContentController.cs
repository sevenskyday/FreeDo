using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample01.Models;

namespace Sample01.Controllers
{
    public class ContentController : Controller
    {
        public readonly ContentModel contents;
        public ContentController(IOptions<ContentModel> option)
        {
            contents = option.Value;
        }
        public IActionResult Index()
        {
            // return View();
            //var contents = new List<ContentModel>();
            //for (int i = 1; i < 11; i++)
            //{
            //    contents.Add(new ContentModel { Id = i, title = $"{i}的标题", content = $"{i}的内容", status = 1, add_time = DateTime.Now.AddDays(-i) });
            //}
            return View(new ContentViewModel { Contents = new List<ContentModel>() { contents } });
        }
    }
}