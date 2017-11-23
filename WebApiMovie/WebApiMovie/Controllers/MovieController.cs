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
        public IActionResult Get(int id)
        {
            var movies = from m in _context.Movie
                         where id == m.ID
                         select m;

            return new ObjectResult(
                 movies.SingleOrDefault<Movie>());
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            _context.Movie.Add(movie);
            _context.SaveChanges();

            return new ObjectResult(movie);
            //return CreatedAtRoute("Get", new { id = movie.ID }, movie);
        }

        // PUT api/movie/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
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

            if (movie.Genre != null)
            {
                movieToChange.Genre = movie.Genre;
            }
            if (movie.Price != null)
            {
                movieToChange.Price = movie.Price;
            }
            if (movie.Rating != null)
            {
                movieToChange.Rating = movie.Rating;
            }
            if (movie.ReleaseDate != null)
            {
                movieToChange.ReleaseDate = movie.ReleaseDate;
            }
            if (movie.Title != null)
            {
                movieToChange.Title = movie.Title;
            }

            _context.Movie.Update(movieToChange);
            _context.SaveChanges();
            return new ObjectResult(movieToChange);
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
