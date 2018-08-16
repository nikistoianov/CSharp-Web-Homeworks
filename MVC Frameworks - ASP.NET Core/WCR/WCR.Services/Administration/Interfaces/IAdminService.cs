using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WCR.Common.Administration.ViewModels;

namespace WCR.Services.Administration.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<TeamViewModel> GetTeams();

        Task<string> DeleteTeamAsync(int id);
    }
}
