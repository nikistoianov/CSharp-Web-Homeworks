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

        public string Title { get; set; }

        public ICollection<UserDetailsViewModel> Users { get; set; }
        public ICollection<MatchViewModel> Matches { get; set; }
        public ICollection<MidResultViewModel> RoundPoints { get; set; }
        public ICollection<MidResultViewModel> BonusPoints { get; set; }
        public ICollection<TotalResultViewModel> TotalPoints { get; set; }
    }
}
