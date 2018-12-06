using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShare.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShare.Web.ViewComponents
{
    [ViewComponent(Name = "PriorityList")]
    public class PriorityListViewComponent:ViewComponent
    {
        private readonly DataContext db;
        public PriorityListViewComponent(DataContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int maxPriority,bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(items);
        }
        private Task<List<ToDoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return db.ToDo.Where(x => x.IsDone == isDone && x.Priority <= maxPriority).ToListAsync();
        }
    }
}
