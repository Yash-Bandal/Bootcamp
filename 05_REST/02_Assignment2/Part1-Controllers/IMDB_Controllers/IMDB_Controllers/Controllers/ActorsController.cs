using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        // Get All Actors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // Get Actor by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // Create Actor
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(Get), new {id = 1}, null);
        }

        // Update Actor
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        // Delete Actor
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
