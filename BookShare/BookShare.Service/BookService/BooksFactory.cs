using BookShare.Data;
using BookShare.Service.Interfaces;
using BookShare.Service.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.BookService
{

    public class BooksFactory : IBookService
    {
        private readonly NovelBook _novel;
        public BooksFactory(NovelBook novel)
        {
            _novel = novel;
        }

        public BaseBook Create(BookTypeEnum type)
        {
            switch (type)
            {
                case BookTypeEnum.NOVEL: return _novel;
                default: throw new ArgumentException("无法识别的type");
            }
        }
    }
}
