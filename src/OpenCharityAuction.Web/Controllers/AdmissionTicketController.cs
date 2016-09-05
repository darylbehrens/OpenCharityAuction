using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.ViewModels;
using System.Security.Claims;
using OpenCharityAuction.Web.Models.Interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using OpenCharityAuction.Entities.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{

    public class AdmissionTicketController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuctionService AuctionService;

        public AdmissionTicketController(IUserService userService, IAuctionService auctionService)
        {
            AuctionService = auctionService;
            UserService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult AddAdmissionTicket(string errorMessage = null)
        {
            ViewData["ErrorMessage"] = errorMessage;
            return View("AddAdmissionTicket");
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmissionTicket(AddAdmissionTicketViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var eventId = await UserService.GetCurrentUsersActiveEvent();
                if (eventId != null)
                {
                    AdmissionTicket ticket = new AdmissionTicket()
                    {
                        Name = vm.Name,
                        Cost = vm.Cost,
                        CreatedBy = UserService.GetUserId(),
                        EventId = eventId.Value
                    };
                    await AuctionService.AddAdmissionTicket(ticket);
                    return RedirectToAction("Index", "AdmissionTicket");
                }
                else
                {
                    return RedirectToAction("AddAdmissionTicket", new { errorMessage = "You must have an active event before you can add tickets" });
                }
            }
            return View("AddAdmissionTicket", vm);

        }
    }
}
