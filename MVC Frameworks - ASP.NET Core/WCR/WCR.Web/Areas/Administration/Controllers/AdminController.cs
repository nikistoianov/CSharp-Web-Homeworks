namespace WCR.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public abstract class AdminController : Controller
    {
    }
}
