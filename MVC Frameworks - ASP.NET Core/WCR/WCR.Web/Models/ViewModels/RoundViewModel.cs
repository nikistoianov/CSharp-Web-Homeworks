using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCR.Web.Models.ViewModels
{
    public class RoundViewModel
    {
        public RoundViewModel()
        {
            this.Users = new List<UserDetailsViewModel>();
            this.Matches = new List<MatchViewModel>();
        }

        public ICollection<UserDetailsViewModel> Users { get; set; }
        public ICollection<MatchViewModel> Matches { get; set; }
    }
}
