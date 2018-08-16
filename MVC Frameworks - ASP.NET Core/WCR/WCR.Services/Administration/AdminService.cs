using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WCR.Common.Administration.ViewModels;
using WCR.Data;
using WCR.Services.Administration.Interfaces;

namespace WCR.Services.Administration
{
    public class AdminService : BaseEFService, IAdminService
    {
        public AdminService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public async Task<string> DeleteTeamAsync(int id)
        {
            var team = await DbContext.Teams.FindAsync(id);
            if (team == null)
            {
                return $"Team with id: {id} not found!";
            }

            DbContext.Teams.Remove(team);
            await DbContext.SaveChangesAsync();

            return null;
        }

        public IEnumerable<TeamViewModel> GetTeams()
        {
            var teams = DbContext.Teams
                .Select(x => new TeamViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    GroupName = x.Group.Name
                })
                .ToList();
            return teams;
        }
    }
}
