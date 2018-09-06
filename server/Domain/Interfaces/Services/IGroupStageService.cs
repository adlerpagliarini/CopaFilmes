using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IGroupStageService
    {
        GroupStage CreateFirstStageGroup(IList<Movie> listOfMovies);
        GroupStage CreateNextStageGroup(IList<Movie> listOfMovies);
        GroupStage PerformStageGroup(GroupStage stage);
    }
}
