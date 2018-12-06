using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShare.Service.Models.BaseModels
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }//当前页
        public int TotalPages { get; private set; }//总页数

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)//count：总条数 ，pageIndex：当前页，pageSize：每页显示行数
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }
        //判断是否为首页
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        //判断是否为尾页
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex = 1, int pageSize = 10)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get;  set; }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get;  set; }
    }

}
