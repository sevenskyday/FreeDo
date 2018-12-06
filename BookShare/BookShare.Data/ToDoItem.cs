using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Data
{
   public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int Priority { get; set; }
    }
}
