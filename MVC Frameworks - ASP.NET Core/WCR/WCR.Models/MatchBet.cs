using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class MatchBet
    {
        public int Id { get; set; }

        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
