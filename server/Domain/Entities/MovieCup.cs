using System.Collections.Generic;

namespace Domain.Entities
{
    public class MovieCup
    {
        public GroupStage FirstGroupStage { get; set; }
        public List<GroupStage> NextGroupStages { get; set; }
        public Movie Winner { get; set; }
        public Movie Second { get; set; }

        public MovieCup()
        {
            NextGroupStages = new List<GroupStage>();
        }
    }
}
