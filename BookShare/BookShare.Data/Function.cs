using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Data
{
    public class Function
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Content { get; set; }
        public string Site { get; set; }
    }
}
