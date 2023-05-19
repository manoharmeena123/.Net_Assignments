using Azure.Storage.Blobs;
using ManoharWebApi.Data;
using ManoharWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManoharWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Test(int id)
        {
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }




        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Category category)
        {

            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=shopifymartapplication;AccountKey=Yp39fujqWao3B7uLdO8bQ3dSrhl5zUaQ9eW+kyB4IDhwfcjbAOGnKgxQSH0hDd2i8H5HpE3lnHQP+ASt00yAbw==;EndpointSuffix=core.windows.net";
            string containerName = "shopifycartimage";

            BlobContainerClient containerCLient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = containerCLient.GetBlobClient(category.CategoryImage.FileName);
            MemoryStream ms = new MemoryStream();
            await category.CategoryImage.CopyToAsync(ms);
            ms.Position = 0;
         await blobClient.UploadAsync(ms);
            category.CategoryImagePath = blobClient.Uri.AbsoluteUri;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categoryDb = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(categoryDb == null)
            {
                NotFound();
            }
           categoryDb.Title = category.Title;
            categoryDb.Description = category.Description;
           
           //                                        _context.Categories.Update(categoryDb);
            await _context.SaveChangesAsync();
            return Ok("Category Updated..");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok("Category Deleted..");
        }
    }
}
 