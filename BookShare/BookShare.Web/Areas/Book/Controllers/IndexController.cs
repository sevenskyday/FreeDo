using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShare.Data;
using BookShare.Service;
using BookShare.Service.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookShare.Web.Areas.Book.Controllers
{
    [Area("Book")]
    public class IndexController : Controller
    {
        private BooksService _booksService;

        public IndexController(BooksService booksService)
        {
            _booksService = booksService;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchNameString, string searchAuthorString, int page = 1, int pageSize = 10)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameParm"] = searchNameString;
            ViewData["AuthorParm"] = searchAuthorString;
            var search = new Search_Book() { Author = searchAuthorString, SortType = sortOrder, Name = searchNameString, PageIndex = page, PageSize = pageSize };
            return View(await _booksService.SearchAsync(search));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string Name, string Author)
        {
            var book = new Creat_Book() { Author = Author, Name = Name, Type = BookTypeEnum.NOVEL };
            var result = await _booksService.CreateAsync(book);
            if (result.IsSucceed)
                return RedirectToAction("Index");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _booksService.GetBook(id.Value);
            if (result == null)
            {
                return NotFound();
            }
            if (!result.IsSucceed)
            {
                return RedirectToAction("Index");
            }
            return View(result.Entity);
        }
        [HttpPost]
        public IActionResult Edit(int id, BookInfo bookInfo)
        {
            if (id != bookInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = _booksService.Update(bookInfo);
                if (result.IsSucceed)
                    return RedirectToAction(nameof(Index));

            }
            return View(bookInfo);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _booksService.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var result = _booksService.Delete(Id);
            return Json(result);
        }
    }
}