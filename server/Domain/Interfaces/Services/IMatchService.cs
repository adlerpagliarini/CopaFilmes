using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IMatchService
    {
        Match CreateMatch(Movie movieOne, Movie movieTwo);
        Match PerformMatch(Movie movieOne, Movie movieTwo);
    }
}
