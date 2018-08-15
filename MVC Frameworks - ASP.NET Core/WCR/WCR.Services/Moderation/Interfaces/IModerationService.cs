using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WCR.Common.Moderation.BindingModels;

namespace WCR.Services.Moderation.Interfaces
{
    public interface IModerationService
    {
        Task<string> CreateGroup(GroupCreationBindingModel model);

        Task<TeamCreationBindingModel> PrepareTeamCreation();

        Task<string> CreateTeam(TeamCreationBindingModel model);
    }
}
