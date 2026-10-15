using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Controllers.Controllers
{
    [Route("api/movies/{movieId}/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // Get All Reviews of a Movie
        [HttpGet]
        public IActionResult Get(int movieId)
        {
            return Ok();
        }

        // Get Actor by Id
        [HttpGet("{id}")]
        public IActionResult Get(int movieId, int id)
        {
            return Ok();
        }

        // Create Actor
        [HttpPost]
        public IActionResult Create(int movieId)
        {
            return CreatedAtAction(nameof(Get), new { id = 1 }, null);
        }

        // Update Actor
        [HttpPut("{id}")]
        public IActionResult Update(int movieId, int id)
        {
            return Ok();
        }

        // Delete Actor
        [HttpDelete("{id}")]
        public IActionResult Delete(int movieId, int id)
        {
            return Ok();
        }
    }
}
