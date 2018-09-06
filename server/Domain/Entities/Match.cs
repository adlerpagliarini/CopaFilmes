using System;

namespace Domain.Entities
{
    public class Match
    {
        public Movie MovieOne { get; set; }
        public Movie MovieTwo { get; set; }
        public Movie Winner { get; private set; }

        public static Match PerformMatch(Movie movieOne, Movie movieTwo)
        {
            var winner = new Movie();

            winner = movieOne.Score > movieTwo.Score ? movieOne : movieTwo;
            if (winner == null) winner = String.Compare(movieOne.Title, movieTwo.Title) >= 0 ? movieOne : movieTwo;

            return new Match() { MovieOne = movieOne, MovieTwo = movieTwo, Winner = winner };
        }
    }
}
