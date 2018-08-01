﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCR.Web.Models.ViewModels
{    
    public class AdminUsersViewModel
    {
        public AdminUsersViewModel()
        {
            this.Users = new List<UserListViewModel>();
        }

        public ICollection<UserListViewModel> Users { get; set; }
    }
}
