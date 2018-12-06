using BookShare.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.Models.Books
{
    public class Creat_Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public BookTypeEnum Type { get; set; }
    }
}
