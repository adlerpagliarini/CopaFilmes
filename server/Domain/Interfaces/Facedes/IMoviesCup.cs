using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Facedes
{
    public interface IMoviesCup
    {
        MovieCup PerformMovieCup(List<Movie> movies);
    }
}
