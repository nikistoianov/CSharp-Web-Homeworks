using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class Match
    {
        public Match()
        {
            this.Bets = new List<MatchBet>();
        }

        public int Id { get; set; }

        public int FirstTeamId { get; set; }
        public Team FirstTeam { get; set; }

        public int SecondTeamId { get; set; }
        public Team SecondTeam { get; set; }

        public int? FirstTeamGoals { get; set; }

        public int? SecondTeamGoals { get; set; }

        public int RoundIndex { get; set; }

        public DateTime Date { get; set; }

        public ICollection<MatchBet> Bets { get; set; }
    }
}
