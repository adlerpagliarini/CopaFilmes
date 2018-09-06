using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class GroupStageService : IGroupStageService
    {
        protected readonly IMatchService _matchService;

        public GroupStageService(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public GroupStage CreateFirstStageGroup(IList<Movie> listOfMovies)
        {
            int listSize = listOfMovies.Count;

            if (listSize == 0)
                return null;

            var GroupStages = new GroupStage();

            int firstElement = 0, lastElement = 0;
            lastElement = listOfMovies.Count - 1;


            while (firstElement < lastElement && listSize > 1)
            {
                GroupStages.Matchs.Add(_matchService.CreateMatch(listOfMovies[firstElement], listOfMovies[lastElement]));
                firstElement++;
                lastElement--;
            }

            return GroupStages;
        }

        public GroupStage CreateNextStageGroup(IList<Movie> listOfMovies)
        {
            if (listOfMovies == null)
                return null;

            var GroupStages = new GroupStage();

            int listSize = listOfMovies.Count;

            int firstElement = 0, lastElement = 0;
            lastElement = listOfMovies.Count - 1;

            for (firstElement = 0; firstElement < lastElement; firstElement += 2)
            {
                GroupStages.Matchs.Add(_matchService.CreateMatch(listOfMovies[firstElement], listOfMovies[firstElement+1]));
            }

            return GroupStages;
        }

        public GroupStage PerformStageGroup(GroupStage stage)
        {
            if (stage == null)
                return null;

            stage.Matchs = stage.Matchs.Select(m => _matchService.PerformMatch(m.MovieOne, m.MovieTwo)).ToList();

            return stage;
        }
    }
}
