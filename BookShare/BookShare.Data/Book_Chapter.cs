using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShare.Data
{
    public class Book_Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Volum_Id { get; set; }
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public Book_Volum Book_Volum { get; set; }
        public virtual ICollection<Book_Paragraph> Book_Paragraphs { get; set; }
    }
}
