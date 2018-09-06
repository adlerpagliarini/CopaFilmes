using System.Collections.Generic;

namespace Domain.Entities
{
    public class GroupStage
    {
        public List<Match> Matchs { get; set; }

        public GroupStage()
        {
            Matchs = new List<Match>();
        }
    }
}
