using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Theater.DTO;
using MF.Theater.Services.Commands;
using MF.Theater.UI.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MF.Theater.UI.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketCommands mTicketCommand;

        public TicketsController(ITicketCommands ticketCommand)
        {
            mTicketCommand = ticketCommand;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(PlayPeriodDto request)
        {
            var currentUserId = HttpContext.User.Identity.GetUserId();
            ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(currentUserId);
            mTicketCommand.Create(request, user.Email);
            return Json("success");
        }
    }
}