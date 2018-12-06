using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.Models.Books
{
   public  class BookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public string Publish { get; set; }
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; }
        public int AminId { get; set; }
        public DateTime CreateDT { get; set; }
    }
}
