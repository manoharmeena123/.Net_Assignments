using System.ComponentModel.DataAnnotations.Schema;

namespace ManoharWebApi.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BookUrl { get; set; }

        public DateTime CreareDate { get; set; }
        public string CreateDate { get; set; }
        public string ISBNNUMBER { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public IFormFile BookFile { get; set; }

        public int BookCoverId { get; set; }
        public BookCover BookCover { get; set; }

        public BookWritter BookWritter {get; set;}
    }
}
