using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class GroupBet
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int FirstTeamPosition { get; set; }

        public int SecondTeamPosition { get; set; }

        public int ThirdTeamPosition { get; set; }

        public int FourthTeamPosition { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
