using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WCR.Web.Areas.Moderation.Pages.Add
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class GroupModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {           
            [Required]
            [Display(Name = "Group name")]
            public string Name { get; set; }

            [Required]
            public DateTime Date { get; set; }

        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            return Page();
        }
    }
}