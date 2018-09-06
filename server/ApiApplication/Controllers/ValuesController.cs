using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Facedes;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMovieService _movies;
        private readonly IMoviesCup _moviesCup;

        public ValuesController(IMovieService movies, IMoviesCup moviesCup)
        {
            _movies = movies;
            _moviesCup = moviesCup;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Match>> Get()
        {
            var listOfMovies = _movies.GetAll();
            var selectedMovies = listOfMovies.Take(8);

            var listOfMoviesById = _movies.GetByIds(new List<string> { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" });

            var result = _moviesCup.PerformMovieCup(listOfMoviesById.ToList());

            var listOfMatchs = new List<Match>();
            foreach(var match in result.FirstGroupStage.Matchs)
                listOfMatchs.Add(match);

            foreach (var groupStage in result.NextGroupStages)
                foreach (var match in groupStage.Matchs)
                    listOfMatchs.Add(match);

            listOfMatchs.Add(new Match() { MovieOne = result.Winner });

            return listOfMatchs.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
