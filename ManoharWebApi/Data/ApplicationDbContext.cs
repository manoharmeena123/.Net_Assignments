
using ManoharWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ManoharWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
        

        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<BookWritter> BookWritters { get; set; }
      
    }
}
