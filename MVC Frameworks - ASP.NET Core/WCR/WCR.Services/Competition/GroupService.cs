namespace WCR.Services.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WCR.Common.Competition.ViewModels;
    using WCR.Common.Constants;
    using WCR.Data;
    using WCR.Services.Competition.Interfaces;

    public class GroupService : BaseEFService, IGroupService
    {
        public GroupService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public IList<GroupViewModel> GetGroups()
        {
            var groups = this.DbContext.Groups
                .OrderBy(x => x.Date)
                .Select(x => new GroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Date = x.Date,
                    Teams = x.Teams
                        .Select(t => new GroupTeamViewModel()
                        {
                            TeamName = t.Name,
                            Position = t.GroupPosition != null ? t.GroupPosition.ToString() : Constants.NO_SCORE,
                            Bets = t.BetsForPosition
                                .Select(b => new TeamBetViewModel()
                                {
                                    UserId = b.UserId,
                                    Score = b.Position.ToString(),
                                    Points = CalculatePoints(t.GroupPosition, b.Position)
                                })
                                .ToArray()
                        })
                        .ToArray()
                })
                .ToArray();

            return groups;
        }

        private int CalculatePoints(int? groupPosition, int position)
        {
            if (groupPosition == null)
            {
                return 0;
            }

            if (groupPosition == position)
            {
                switch (position)
                {
                    case 1:
                        return Constants.POINTS_GROUP_1;
                    case 2:
                        return Constants.POINTS_GROUP_2;
                    case 3:
                        return Constants.POINTS_GROUP_3;
                    default:
                        return Constants.POINTS_GROUP_4;
                }
            }

            return 0;
        }

        public void ArrangeTeamBets(ICollection<GroupViewModel> groups, ICollection<UserDetailsViewModel> users, string currentUserId, bool isAdmin)
        {
            foreach (var group in groups)
            {
                foreach (var team in group.Teams)
                {
                    var newTeamBets = new List<TeamBetViewModel>();
                    foreach (var user in users)
                    {
                        var teamBet = team.Bets.FirstOrDefault(x => x.UserId == user.Id);
                        if (teamBet == null)
                        {
                            teamBet = new TeamBetViewModel() { UserId = user.Id, Score = Constants.NO_SCORE };
                        }

                        var isCurrentUser = currentUserId != null && currentUserId == user.Id;
                        var isStarted = group.Date < DateTime.Now;

                        teamBet.Hidden = !isAdmin && !isStarted && !isCurrentUser;
                        teamBet.Current = (isCurrentUser && !isStarted) || (isAdmin && teamBet.Score != Constants.NO_SCORE);
                        teamBet.GroupId = group.Id;
                        teamBet.ClassName = GetScoreClass(teamBet.Points);

                        if (teamBet.Points > 0)
                        {
                            teamBet.Score += $" ({teamBet.Points})";
                        }

                        newTeamBets.Add(teamBet);
                    }
                    team.Bets = newTeamBets;
                }
            }
        }
        private string GetScoreClass(int points)
        {
            switch (points)
            {
                case 0:
                    return Constants.CLASS_NO_SCORE;
                default:
                    return Constants.CLASS_BIG_SCORE;
            }
        }
    }
}
