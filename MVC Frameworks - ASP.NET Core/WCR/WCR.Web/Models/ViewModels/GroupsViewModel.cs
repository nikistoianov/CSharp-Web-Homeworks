using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCR.Models;

namespace WCR.Web.Models.ViewModels
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
