using ManoharWebApi.Data;
using ManoharWebApi.Helper;
using ManoharWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManoharWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Book book)
        {


            book.ImageUrl = await FileHelper.UploadImage(book.ImageFile);
            book.BookUrl = await FileHelper.UploadUrl(book.BookFile);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }
    }
}
