using BookShare.Data;
using BookShare.Service.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.Models.Books
{
    /// <summary>
    /// 搜索模型
    /// </summary>
    public class Search_Book:PageInfo
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public DateTime? BeganCreateDT { get; set; }
        public DateTime? EndCreateDT { get; set; }

        public BookTypeEnum? Type { get; set; }

        public string SortType { get; set; }


    }
}
