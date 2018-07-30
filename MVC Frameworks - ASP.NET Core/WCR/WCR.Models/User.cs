using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WCR.Models
{
    public class User : IdentityUser
    {
        public string ShortName { get; set; }
    }
}
