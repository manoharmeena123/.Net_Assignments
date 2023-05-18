using System.ComponentModel.DataAnnotations;

namespace ManoharWebApi.Model
{
    public class BookWritter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        public string ImageFile { get; set; }

        public ICollection<Book> Books { get; set;}
        public ICollection<BookCover> BookCovers { get; set;}
    }
}
