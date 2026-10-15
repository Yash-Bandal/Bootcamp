using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // Get All Generes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // Get Genere by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // Create Genere
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(Get), new { id = 1 }, null);
        }

        // Update Genere
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        // Delete Genere
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
