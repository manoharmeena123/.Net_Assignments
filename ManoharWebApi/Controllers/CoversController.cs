using ManoharWebApi.Data;
using ManoharWebApi.Helper;
using ManoharWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManoharWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoversController(ApplicationDbContext context)
        {
            _context = context;
        }




        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookCover cover)
        {


            cover.ImageUrl = await FileHelper.UploadImage(cover.ImageFile);
            await _context.BookCovers.AddAsync(cover);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }
    }
}

