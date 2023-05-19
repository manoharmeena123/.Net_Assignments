using System.ComponentModel.DataAnnotations.Schema;

namespace ManoharWebApi.Model
{
    public class BookCover
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
            
        public ICollection<Book> Books { get; set; }
        public ICollection<BookCover> BookCovers { get; set; }
    }
}
