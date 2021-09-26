using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository movieRepository;
        public MovieController()
        {
            movieRepository = new MovieRepository();
        }

        [HttpPost]
        public void AddMovie([FromBody] MovieAdd movieAdd)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.MovieName = movieAdd.MovieName;
                movie.Plot = movieAdd.Plot;
                movie.Poster = movieAdd.Poster;
                movie.ReleaseDate = movieAdd.ReleaseDate;
                var movieid = movieRepository.AddMovie(movie);
                movieRepository.AddActorMovie(movieid,movieAdd.ActorId);
                movieRepository.AddProducerMovie(movieid, movieAdd.ProducerId);

            }
        }

        [HttpGet]
        public IEnumerable<ReturnMovie> GetAllActorsNames()
        {
            try
            {
                var actors = movieRepository.ReturnMovies();
                return actors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
