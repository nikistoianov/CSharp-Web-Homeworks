using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WCR.Models
{
    public class Group
    {
        public Group()
        {
            this.Bets = new List<GroupBet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("FirstTeam")]
        public int FirstTeamId { get; set; }
        public Team FirstTeam { get; set; }

        [ForeignKey("SecondTeam")]
        public int SecondTeamId { get; set; }
        public Team SecondTeam { get; set; }

        [ForeignKey("ThirdTeam")]
        public int ThirdTeamId { get; set; }
        public Team ThirdTeam { get; set; }

        [ForeignKey("FourthTeam")]
        public int FourthTeamId { get; set; }
        public Team FourthTeam { get; set; }

        public int? FirstTeamPosition { get; set; }

        public int? SecondTeamPosition { get; set; }

        public int? ThirdTeamPosition { get; set; }

        public int? FourthTeamPosition { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GroupBet> Bets { get; set; }
    }
}
