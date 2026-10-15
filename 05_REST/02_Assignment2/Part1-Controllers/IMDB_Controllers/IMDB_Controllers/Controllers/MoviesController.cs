using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //Get all Movies
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok();
        }

        //Get Movie By Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        //Create a Movie
        [HttpPost]
        public IActionResult Create()
        {
            return CreatedAtAction(nameof(Get), new {id = 1}, null);
        }

        //Update a Movie
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok();
        }

        //Delete a Movie
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
