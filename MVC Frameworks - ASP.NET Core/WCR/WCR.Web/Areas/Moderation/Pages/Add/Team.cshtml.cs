using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WCR.Web.Areas.Moderation.Pages.Add
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class TeamModel : PageModel
    {
        public TeamModel()
        {
            this.Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public InputModel()
            {
                this.Groups = new List<SelectListItem>();
            }

            [Required]
            [Display(Name = "Team name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "You have to specify a group.")]
            [Display(Name = "Group")]
            public int GroupId { get; set; }

            [BindNever]
            public IEnumerable<SelectListItem> Groups { get; set; }
        }

        public void OnGet()
        {
            this.Input.Groups = new List<SelectListItem> { new SelectListItem { Value = "1" , Text = "Test"} };
        }
    }
}