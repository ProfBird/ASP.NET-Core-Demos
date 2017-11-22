using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiMovie.Win.Models;

namespace WebApiMovie.Win.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        // GET api/movie
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var movies = from m in _context.Movie
                         select m;
            
            // Return the movie with the specified title, or 
            // all movies in the database if no title was specified
            return movies.ToList();
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/movie
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
