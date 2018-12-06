using Microsoft.EntityFrameworkCore;
using System;

namespace BookShare.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public  DbSet<Book> Books { get; set; }
        public DbSet<Book_Volum> Book_Volums { get; set; }
        public DbSet<Book_Chapter> Book_Chapters { get; set; }
        public DbSet<Book_Paragraph> Book_Paragraphs { get; set; }
        public DbSet<Book_Tag> Book_Tags { get; set; }
        public DbSet<Book_Relation_Tag> Book_Relation_Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ToDoItem> ToDo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<Book_Volum>();
            modelBuilder.Entity<Book_Chapter>();
            modelBuilder.Entity<Book_Chapter>();
            modelBuilder.Entity<Book_Tag>();
            modelBuilder.Entity<Book_Relation_Tag>();
            modelBuilder.Entity<Genre>();
            modelBuilder.Entity<ToDoItem>();
        }
    }
}
