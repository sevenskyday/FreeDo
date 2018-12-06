using BookShare.Service.Interfaces;
using BookShare.Service.Models.BaseModels;
using BookShare.Service.Models.Books;
using Microsoft.EntityFrameworkCore;
using BookShare.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Service.BookService
{
    public abstract class BaseBook : IBookService
    {
        // protected readonly IConfiguration Configuration;
        //protected DataContext _db;

        protected BaseBook()
        {
            //_db = db;
        }
        //protected int Id { get; set; }
        //protected string Name { get; set; }
        //protected string SubName { get; set; }
        //protected string Author { get; set; }
        //protected string CoverImage { get; set; }
        //protected string Publish { get; set; }
        //protected decimal Price { get; set; }
        //protected decimal RealPrice { get; set; }
        //protected int AminId { get; set; }
        //protected DateTime CreateDT { get; set; }
        public abstract Book Create(string name, string author);
        //public abstract ServiceResult Create(string name, string author);
        //public abstract ServiceResult UpdateName(string name);
        //public abstract ServiceResult UpdateAuthor(string author);
        //public abstract ServiceResult UpdatePrice(decimal price);
        //public abstract ServiceResult Delete(int Id);
        //public abstract ServiceResult<BookInfo> GetBook(int Id);

    }
}
