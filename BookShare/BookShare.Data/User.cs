using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string NickName { get; set; }
        public int Sex { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDT { get; set; }
        public string Password { get; set; }

    }
}
