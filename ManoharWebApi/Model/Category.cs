using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManoharWebApi.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="TITLE CAN NOT BE NULL..")]
        public string Title { get; set; } = string.Empty; 
        [Required]
        public string Description { get; set; } = string.Empty;
     
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [NotMapped]
        public IFormFile CategoryImage { get; set; }    
        public string CategoryImagePath { get; set; }
    }
}
