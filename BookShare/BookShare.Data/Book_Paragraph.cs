using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShare.Data
{
    public class Book_Paragraph
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Chapter_Id { get; set; }
        public int Volum_Id { get; set; }
        public int Book_Id { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public Book_Chapter Book_Chapter { get; set; }
    }
}
