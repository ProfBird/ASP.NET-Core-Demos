using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiMovie.Mac.Models;

namespace WebApiMovie.Mac.Controllers
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
        public IActionResult Get(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.ID == id);

            if (movie == null)
            {
                return NotFound();
            }
            return new ObjectResult(movie);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            _context.Movie.Add(movie);
            _context.SaveChanges();

            // return CreatedAtRoute("Get", new { id = movie.ID }, movie);
            return new ObjectResult(movie);
        }

        // PUT api/movie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Movie movie)
        {
            if (movie == null || movie.ID != id)
            {
                return BadRequest();
            }

            var movieToChange = _context.Movie.FirstOrDefault(m => m.ID == id);
            if (movieToChange == null)
            {
                return NotFound();
            }

            movieToChange.Genre = movie.Genre;
            movieToChange.Price = movie.Price;
            movieToChange.Rating = movie.Rating;
            movieToChange.ReleaseDate = movie.ReleaseDate;
            movieToChange.Title = movie.Title;
 
            _context.Movie.Update(movieToChange);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
