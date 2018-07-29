using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WCR.Web.Data
{
    public class WCRDbContext : IdentityDbContext
    {
        public WCRDbContext(DbContextOptions<WCRDbContext> options)
            : base(options)
        {
        }
    }
}
