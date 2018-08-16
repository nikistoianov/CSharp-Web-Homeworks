using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WCR.Common.Moderation.BindingModels;
using WCR.Services.Moderation.Interfaces;

namespace WCR.Web.Areas.Moderation.Pages.Add
{
    public class MatchModel : PageModel
    {
        private readonly IModerationService moderationService;

        public MatchModel(IModerationService moderationService)
        {
            this.Input = new MatchCreationBindingModel();
            this.moderationService = moderationService;
        }

        [BindProperty]
        public MatchCreationBindingModel Input { get; set; }

        public async void OnGet()
        {
            var model = await this.moderationService.PrepareMatchCreation();
            this.Input = model;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!this.ModelState.IsValid)
            {
                this.Input = await this.moderationService.PrepareMatchCreation();
                return Page();
            }

            var result = await this.moderationService.CreateMatch(Input);
            if (result == null)
            {
                return Redirect(returnUrl ?? "/");
            }
            ModelState.AddModelError(string.Empty, result);
            return Page();
        }
    }
}