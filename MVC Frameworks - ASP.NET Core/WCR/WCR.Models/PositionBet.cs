using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class PositionBet
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int Position { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
