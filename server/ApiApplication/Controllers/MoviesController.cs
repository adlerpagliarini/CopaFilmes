using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Facedes;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _movieService;
        private readonly IMoviesCup _moviesCup;

        public MoviesController(IMoviesCup moviesCup, IMovieService movieService)
        {
            _moviesCup = moviesCup;
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _movieService.GetAll().ToList();
        }

        [HttpPost]
        public ActionResult<MovieCup> Post([FromBody] string[] ids)
        {
            var selectedMovies = _movieService.GetByIds(ids);
            var movieCup = _moviesCup.PerformMovieCup(selectedMovies.ToList());

            return movieCup;
        }
    }
}