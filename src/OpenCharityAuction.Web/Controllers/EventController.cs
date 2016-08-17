using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.ViewModels;
using System.Security.Claims;
using OpenCharityAuction.Web.Models.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IAuctionService AuctionService;
        private readonly IUserService UserService;

        public EventController(IAuctionService auctionService, IUserService userService)
        {
            AuctionService = auctionService;
            UserService = userService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult AddEvent()
        {
            return View("AddEvent");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEvent(AddEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Entities.Models.Event newEvent = new Entities.Models.Event()
                {
                    EventDate = model.EventDate.Value,
                    EventName = model.EventName,
                    CreatedBy = UserService.GetUserId()
                };
                Entities.Models.Event testEvent;
                await AuctionService.AddEvent(newEvent, ev => testEvent = ev);
                return RedirectToAction("Index", "Event");
            }
            return View("AddEvent", model);
       
        }
    }
}
