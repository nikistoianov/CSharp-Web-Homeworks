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
            this.Teams = new List<Team>();
            this.Bets = new List<PositionBet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime Date { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<PositionBet> Bets { get; set; }
    }
}
