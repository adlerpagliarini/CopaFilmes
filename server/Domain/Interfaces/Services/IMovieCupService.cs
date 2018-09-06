using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IMovieCupService
    {
        MovieCup CreateCup(IList<Movie> listOfMovies);
        MovieCup PerformFirstGroupStage(MovieCup movieCup);
        MovieCup PerformNextGroupStage(MovieCup movieCup);
    }
}
