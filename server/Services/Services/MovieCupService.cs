using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class MovieCupService : IMovieCupService
    {
        protected readonly IGroupStageService _groupStageService;

        public MovieCupService(IGroupStageService groupStageService)
        {
            _groupStageService = groupStageService;
        }

        public MovieCup CreateCup(IList<Movie> listOfMovies)
        {
            var MovieCup = new MovieCup
            {
                FirstGroupStage = _groupStageService.CreateFirstStageGroup(listOfMovies)
            };
            return MovieCup;
        }

        public MovieCup PerformFirstGroupStage(MovieCup movieCup)
        {
            if (movieCup == null || movieCup.FirstGroupStage == null)
                return null;

            var listOfWinners = _groupStageService.PerformStageGroup(movieCup.FirstGroupStage).Matchs.Select(m => m.Winner).ToList();
            movieCup.NextGroupStages.Add(_groupStageService.CreateNextStageGroup(listOfWinners));

            return movieCup;
        }

        public MovieCup PerformNextGroupStage(MovieCup movieCup)
        {
            if (movieCup == null || movieCup.NextGroupStages == null)
                return null;

            var listOfWinners =  _groupStageService.PerformStageGroup(movieCup.NextGroupStages.LastOrDefault())
                                    .Matchs.Select(m => m.Winner).ToList();

            if (movieCup.NextGroupStages.LastOrDefault().Matchs.Count > 1)
                movieCup.NextGroupStages.Add(_groupStageService.CreateNextStageGroup(listOfWinners));
            else
            {
                var match = movieCup.NextGroupStages.LastOrDefault().Matchs.SingleOrDefault();
                movieCup.Winner = match.Winner;
                movieCup.Second = match.MovieOne.Id == match.Winner.Id ? match.MovieTwo : match.MovieOne;
            }

            return movieCup;
        }

        public MovieCup GetRankingList(MovieCup movieCup)
        {
            if (movieCup == null)
                return null;

            var listOfMovies = movieCup.NextGroupStages.LastOrDefault().Matchs;

            return movieCup;
        }

    }
}
