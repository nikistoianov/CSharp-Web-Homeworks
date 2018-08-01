using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.MatchBets = new List<MatchBet>();
            this.GroupBets = new List<GroupBet>();
        }

        public string ShortName { get; set; }

        public ICollection<MatchBet> MatchBets { get; set; }

        public ICollection<GroupBet> GroupBets { get; set; }

    }
}
