using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Models.ViewModels
{
    public class LinkViewModel
    {
        public int Id { get; set; }

        public string DisplayText { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }
    }
}
