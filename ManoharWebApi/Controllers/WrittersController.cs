using Azure.Storage.Blobs;
using ManoharWebApi.Data;
using ManoharWebApi.Helper;
using ManoharWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManoharWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WrittersController : ControllerBase
    {
     private readonly ApplicationDbContext _context;

        public WrittersController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookWritter writer)
        {

          
       writer.ImageUrl =await FileHelper.UploadImage(writer.ImageFile);
            await _context.BookWritters.AddAsync(writer);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }
    }
}
