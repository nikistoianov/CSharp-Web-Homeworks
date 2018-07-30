using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WCR.Models;

namespace WCR.Web.Data
{
    public class WCRDbContext : IdentityDbContext<User>
    {
        public WCRDbContext(DbContextOptions<WCRDbContext> options)
            : base(options)
        {
        }
    }
}
