﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Models.BindingModels
{
    public class UserLoginBindingModel
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
