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
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchBet> MatchBets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupBet> GroupBets { get; set; }

        public WCRDbContext(DbContextOptions<WCRDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Group>()
                .Property(x => x.FirstTeam)
            base.OnModelCreating(builder);
        }
    }
}
