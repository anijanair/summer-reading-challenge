
namespace Summer_Reading_Challenge.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookContext : DbContext
    {
        public BookContext()
            : base("name=BooksDBEntities")
        {
        }
   
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
