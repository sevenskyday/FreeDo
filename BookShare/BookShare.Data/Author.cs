using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShare.Data
{
    public class Author
    {
        public int Id { get; set; }
        public bool IsUser { get; set; }
        public int? UserId { get; set; }
        public string NickName { get; set; }
        public AuthorLevelEnum Level { get; set; }
        [StringLength(500)]
        public string SimpleDesc { get; set; }
        public DateTime CreateDT { get; set; }
       // public Nullable<User> User { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public enum AuthorLevelEnum
    {
        ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN
    }

}
