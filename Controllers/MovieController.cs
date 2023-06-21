using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("Movies")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> movies = new() {
            new Movie("The Dark Knight", "Christopher Nolan", "Action", 2008, 9),
            new Movie("Inception", "Christopher Nolan", "Sci-Fi", 2010, 8),
            new Movie("Pulp Fiction", "Quentin Tarantino", "Crime", 1994, 9),
            new Movie("The Shawshank Redemption", "Frank Darabont", "Drama", 1994, 9),
            new Movie("The Godfather", "Francis Ford Coppola", "Crime", 1972, 9),
            new Movie("The Matrix", "Lana Wachowski, Lilly Wachowski", "Sci-Fi", 1999, 8),
            new Movie("Fight Club", "David Fincher", "Drama", 1999, 8),
            new Movie("Star Wars: Episode IV - A New Hope", "George Lucas", "Sci-Fi", 1977, 8),
            new Movie("The Lord of the Rings: The Fellowship of the Ring", "Peter Jackson", "Fantasy", 2001, 9),
            new Movie("Forrest Gump", "Robert Zemeckis", "Drama", 1994, 8)
        };

        [HttpPost]
        [Route("AddMovie")]
        public ActionResult<Movie> AddMovie(Movie movie){
            movies.Add(movie);
            return Ok(movie);
        }




        [HttpGet]
        public ActionResult<List<Movie>> GetMovies([FromQuery] int? year, [FromQuery] int? rating){
            if(!movies.Any()){
                return BadRequest("Movies Not Found");
            }
            if(year != null && rating != null){
                return Ok(movies.FindAll(x => x.Year >= year && x.Rating >= rating));
            } else if(year != null){
                return Ok(movies.FindAll(x => x.Year >= year));
            } else if(rating != null){
                return Ok(movies.FindAll(x => x.Rating >= rating));
            } else{
                return Ok(movies);
            }
        }

        [HttpGet("ByTitle/{title}")]
        public ActionResult<Movie> GetMovieByTitle(string title){
            if(title == null || movies.Exists(x => x.Title == title)){
                return BadRequest("Movie Not Found");
            }
            Movie? movie = movies.FirstOrDefault(x => x.Title == title);
            return Ok(movie);
        }

        [HttpGet("ByGenre/{genre}")]
        public  ActionResult<List<Movie>> GetMoviesByGenre(string genre, [FromQuery] int? year, [FromQuery] int? rating){
            List<Movie> movieList = movies.FindAll(x => x.Genre == genre);
            if(!movieList.Any()){
                return BadRequest("Movies Not Found");
            }
            return Ok(movieList);
        }

        [HttpGet("ByYear/{year}")]
        public ActionResult<List<Movie>> GetMoviesByYear(int year){
            List<Movie> movieList = movies.FindAll(x => x.Year == year);
            if(!movieList.Any()){
                return BadRequest("Movies Not Found");
            }
            return Ok(movieList);
        }

        [HttpGet("ByRating/{rating}")]
        public ActionResult<List<Movie>> GetMoviesByRating(int rating){
            List<Movie> movieList = movies.FindAll(x => x.Rating == rating);
            if(!movieList.Any()){
                return BadRequest("Movies Not Found");
            }
            return Ok(movieList);
        }

        [HttpGet("test")]
        public ActionResult<Movie> GetTestMovie(){
            return StatusCode(501, "Endpoint not implemented");
        }
    }
}