using BookShare.Data;
using BookShare.Service.Models.BaseModels;
using BookShare.Service.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using BookShare.Tool;
using BookShare.Service.BookService;
using BookShare.Service.Interfaces;

namespace BookShare.Service
{

    public class BooksService: IBookService
    {
        private readonly BooksFactory _bookFactory;
        private DataContext _db;

        public List<Book> BookList { get; set; }

        public Book Book { get; set; }

        public BooksService(BooksFactory bookFactory, DataContext db)
        {
            _bookFactory = bookFactory;
            _db = db;
        }

        public async Task<ServiceResult> CreateAsync(Creat_Book book)
        {
            try
            {
                var _book = _bookFactory.Create(book.Type).Create(book.Name, book.Author);
                var query = await _db.Books.FirstOrDefaultAsync(x => x.Name == _book.Name && x.Author == _book.Author);
                if (query != null)
                {
                    return ServiceResult.Error("数据已经存在");
                }
                await _db.Books.AddAsync(_book);
                await _db.SaveChangesAsync();
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceResult.Error(ex);
            }

        }

        public async Task<ServiceResult<PaginatedList<Book>>> SearchAsync(Search_Book search)
        {
            try
            {
                var books = from b in _db.Books select b;
                if(search.Type.HasValue)
                {
                    books = books.Where(x => x.Type == search.Type.Value);
                }
                if(search.Name.IsNotNull())
                {
                    books = books.Where(x => x.Name.Contains(search.Name));
                }
                if(search.Author.IsNotNull())
                {
                    books = books.Where(x => x.Author.Contains(search.Author));
                }
                if(search.BeganCreateDT.HasValue)
                {
                    books = books.Where(x => x.CreateDT >= search.BeganCreateDT.Value);
                }
                if(search.EndCreateDT.HasValue)
                {
                    books = books.Where(x => x.CreateDT< search.EndCreateDT.Value);
                }
                switch (search.SortType)
                {
                    case "createdt_desc":
                        books = books.OrderByDescending(x => x.CreateDT);
                        break;
                    case "createdt":
                        books = books.OrderBy(x => x.CreateDT);
                        break;
                    case "name_desc":
                        books = books.OrderByDescending(x => x.Name);
                        break;
                    case "name":
                        books = books.OrderBy(x => x.Name);
                        break;
                    case "author_desc":
                        books = books.OrderByDescending(s => s.Author);
                        break;
                    case "author":
                        books = books.OrderBy(s => s.Author);
                        break;
                    default:
                        books = books.OrderByDescending(s => s.Id);
                        break;

                }
                var result= await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), search.PageIndex, search.PageSize);
                return ServiceResult<PaginatedList<Book>>.Success(result);
            }
            catch (Exception ex)
            {

                return ServiceResult<PaginatedList<Book>>.Error(ex);
            }
        }

        public  ServiceResult Delete(int Id)
        {
            var query = _db.Books.FirstOrDefaultAsync(q => q.Id == Id);
            if (query.IsCompleted && query.Result == null)
            {
                return ServiceResult.Error("数据不存在");
            }
            else
            {
                _db.Books.Remove(query.Result);
                _db.SaveChanges();
                return ServiceResult.Create(true, "操作成功");
            }
        }
        public  ServiceResult<BookInfo> GetBook(int Id)
        {
            //string query = "SELECT * FROM Department WHERE DepartmentID = {0}";
            //var department = await _db.Books
            //    .FromSql(query, id)
            //    .Include(d => d.Administrator)
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync();
            //如果正在跟踪大量实体，并且这些方法之一在循环中多次调用，通过使用ChangeTracker.AutoDetectChangesEnabled属性暂时关闭自动脏值检测，能够显著改进性能。
            //_context.ChangeTracker.AutoDetectChangesEnabled = false;
            var query = _db.Books.FirstOrDefaultAsync(q => q.Id == Id);
            if (query.IsCompleted && query.Result == null)
            {
                return ServiceResult<BookInfo>.Error("数据不存在");
            }
            else
            {
                var entity = new BookInfo()
                {
                    AminId = query.Result.AminId,
                    Author = query.Result.Author,
                    CoverImage = query.Result.CoverImage,
                    Name = query.Result.Name
                };

                return ServiceResult<BookInfo>.Success(entity);
            }

        }

        public ServiceResult Update(BookInfo book)
        {
            var query = _db.Books.FirstOrDefaultAsync(q => q.Id == book.Id);
            if (query.IsCompleted && query.Result == null)
            {
                return ServiceResult.Error("数据不存在");
            }
            else
            {
                query.Result.AminId = book.AminId;
                query.Result.Author = book.Author;
                query.Result.CoverImage = book.CoverImage;
                query.Result.CreateDT = book.CreateDT;
                query.Result.Name = book.Name;
                query.Result.Price = book.Price;
                query.Result.Publish = book.Publish;
                query.Result.RealPrice = book.RealPrice;
                query.Result.SubName = book.SubName;
                _db.SaveChanges();
                return ServiceResult.Create(true, "操作成功");
            }
        }
    }
}
