using Domain.Entities;
using Domain.Interfaces.Facedes;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Services.Facedes
{
    public class MoviesCup : IMoviesCup
    {
        protected readonly IMovieCupService _movieCupService;

        public MoviesCup(IMovieCupService movieCupService)
        {
            _movieCupService = movieCupService;
        }

        public MovieCup PerformMovieCup(List<Movie> movies)
        {
            MovieCup movieCup = new MovieCup();
            movieCup = _movieCupService.CreateCup(movies);
            movieCup = _movieCupService.PerformFirstGroupStage(movieCup);
            movieCup = DoMatchsUntilHaveWinner(movieCup);

            return movieCup;
        }

        private MovieCup DoMatchsUntilHaveWinner(MovieCup movieCup)
        {
            if (movieCup.Winner != null)
                return movieCup;

            movieCup = _movieCupService.PerformNextGroupStage(movieCup);
            return DoMatchsUntilHaveWinner(movieCup);
        }
    }
}
