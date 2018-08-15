using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using WCR.Common.Moderation.BindingModels;
using WCR.Data;
using WCR.Models;
using WCR.Services.Moderation.Interfaces;

namespace WCR.Services.Moderation
{
    public class ModerationService : BaseEFService, IModerationService
    {
        public ModerationService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public async Task<string> CreateGroup(GroupCreationBindingModel model)
        {
            var existingGroupName = DbContext.Groups.Any(x => x.Name == model.Name);
            if (existingGroupName)
            {
                return $"Group with name {model.Name} exists.";
            }

            var group = Mapper.Map<Group>(model);

            await DbContext.Groups.AddAsync(group);
            await DbContext.SaveChangesAsync();

            return null;
        }

        public Task<TeamCreationBindingModel> PrepareTeamCreation()
        {
            var groups = DbContext.Groups.ToArray();
            var groupList = new List<SelectListItem>();
            foreach (var group in groups)
            {
                var item = new SelectListItem { Value = group.Id.ToString(), Text = group.Name };
                groupList.Add(item);
            }

            var result = new TeamCreationBindingModel() { Groups = groupList };
            return Task.FromResult(result);
        }

        public async Task<string> CreateTeam(TeamCreationBindingModel model)
        {
            var existingTeam = DbContext.Teams.Any(x => x.Name == model.Name);
            if (existingTeam)
            {
                return $"Team with name {model.Name} exists.";
            }

            var team = Mapper.Map<Team>(model);

            await DbContext.Teams.AddAsync(team);
            await DbContext.SaveChangesAsync();

            return null;
        }

    }
}
