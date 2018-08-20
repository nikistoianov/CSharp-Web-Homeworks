using System.Collections.Generic;
using WCR.Common.Competition.ViewModels;

namespace WCR.Services.Competition.Interfaces
{
    public interface IRoundService
    {
        ICollection<MatchViewModel> GetMatches(int roundIndex, ICollection<UserDetailsViewModel> users);
    }
}
