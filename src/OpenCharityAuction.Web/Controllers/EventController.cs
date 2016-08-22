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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> SelectCurrentEvent()
        {
            var selectEventVm = new SelectCurrentEventViewModel();
            await AuctionService.GetAllEvents(ev => selectEventVm.Events = ev);
            selectEventVm.Events = selectEventVm.Events.OrderByDescending(x => x.EventDate).ToList();
            return View("SelectCurrentEvent", selectEventVm);
        }

        public async Task<IActionResult> SelectCurrentEvent()
    }
}
