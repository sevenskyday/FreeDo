using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShare.Data
{
    public class Book_Relation_Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }
        //public virtual ICollection<Book> Books { get; set; }
        //public virtual ICollection<Book_Tag> Book_Tags { get; set; }
    }
}
