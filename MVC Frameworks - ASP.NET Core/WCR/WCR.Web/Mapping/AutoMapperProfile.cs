using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCR.Common.Competition.ViewModels;
using WCR.Common.Moderation.BindingModels;
using WCR.Models;
using WCR.Web.Models.ViewModels;

namespace WCR.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<Group, GroupCreationBindingModel>().ReverseMap();
            this.CreateMap<Team, TeamCreationBindingModel>().ReverseMap();
            this.CreateMap<Match, MatchCreationBindingModel>().ReverseMap();
        }
    }
}
