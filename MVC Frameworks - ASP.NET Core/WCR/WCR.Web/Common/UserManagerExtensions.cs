﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCR.Models;

namespace WCR.Web.Common
{
    public static class UserManagerExtensions
    {
        public static bool IsFirstUser(this UserManager<User> userManager)
        {
            return !userManager.Users.Any();
        }

        public static async Task<string> MakeAdminIfFirst(this UserManager<User> userManager, User user)
        {
            //var users = userManager.Users.Count();
            if (userManager.Users.Count() == 1)
            {
                var result = await userManager.AddToRoleAsync(user, "Administrator");
                if (!result.Succeeded)
                {

                }
            }

            return "";
        }
    }
}