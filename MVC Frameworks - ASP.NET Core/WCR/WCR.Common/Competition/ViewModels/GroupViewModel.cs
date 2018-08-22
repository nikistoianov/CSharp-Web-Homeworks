using System;
using System.Collections.Generic;

namespace WCR.Common.Competition.ViewModels
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            this.Teams = new List<GroupTeamViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<GroupTeamViewModel> Teams { get; set; }
    }
}