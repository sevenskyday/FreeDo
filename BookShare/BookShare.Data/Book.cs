using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShare.Data
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public string Publish { get; set; }
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; }
        public int AminId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public BookTypeEnum Type { get; set; }
        public DateTime CreateDT { get; set; }
        public DateTime UpdateDT { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublisDT { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public BookStateEnum State { get; set; }
        public bool Delete { get; set; } = false;
        public virtual ICollection<Book_Volum> Book_Volums { get; set; }
    }
    public enum BookTypeEnum
    {
        NOVEL=1,
        POETRY=2,
        PROSE=3,
        DRAMA=4,
        TOOLBOOK=5
    }
    public enum BookStateEnum
    {
        NOSTART=0,
        NEWSTART=1,
        SERIAL=2,
        FINISH=3,
        INTERRUPT=4,
        CLOSE=5
    }

}
