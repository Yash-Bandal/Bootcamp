using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        // Get All Producers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // Get Producer by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // Create Producer
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(Get), new { id = 1 }, null);
        }

        // Update Producer
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        // Delete Producer
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
