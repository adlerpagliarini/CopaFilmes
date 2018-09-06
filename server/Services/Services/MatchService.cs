using Domain.Entities;
using Domain.Interfaces.Services;

namespace Services.Services
{
    public class MatchService : IMatchService
    {
        public Match CreateMatch(Movie movieOne, Movie movieTwo)
        {
            return new Match(){ MovieOne = movieOne, MovieTwo = movieTwo };
        }
        public Match PerformMatch(Movie movieOne, Movie movieTwo)
        {
            return Match.PerformMatch(movieOne, movieTwo);
        }
    }
}
