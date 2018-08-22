using System.Collections.Generic;

namespace WCR.Common.Competition.ViewModels
{
    public class GroupTeamViewModel
    {
        public GroupTeamViewModel()
        {
            this.Bets = new List<TeamBetViewModel>();
        }

        public string TeamName { get; set; }

        public string Position { get; set; }

        public ICollection<TeamBetViewModel> Bets { get; set; }
    }
}