using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Common.Competition.ViewModels
{
    public class GroupsViewModel
    {
        public GroupsViewModel()
        {
            this.Users = new List<UserDetailsViewModel>();
        }

        public List<UserDetailsViewModel> Users { get; set; }
    }
}
