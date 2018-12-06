using BookShare.Data;
using BookShare.Service.Models.BaseModels;
using BookShare.Service.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Service.BookService
{
    public class NovelBook : BaseBook
    {


        public NovelBook()
        {
        }

        public override Book Create(string name, string author)
        {

            var book = new Book()
            {
                Author = author,
                AminId = 0,
                Name = name,
                CreateDT = DateTime.Now
            };
            return book;

        }

    }
}
