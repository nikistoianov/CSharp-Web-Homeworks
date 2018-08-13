using System;
using System.Collections.Generic;

namespace WCR.Web.Models.ViewModels
{
    public class MatchViewModel
    {
        public DateTime Date { get; set; }

        public string FirstTeam { get; set; }

        public string SecondTeam { get; set; }

        public ICollection<ScoreViewModel> MyProperty { get; set; }
    }
}