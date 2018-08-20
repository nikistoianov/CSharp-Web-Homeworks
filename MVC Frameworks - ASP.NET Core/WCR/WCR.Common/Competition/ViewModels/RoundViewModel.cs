using System.Collections.Generic;

namespace WCR.Common.Competition.ViewModels
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
