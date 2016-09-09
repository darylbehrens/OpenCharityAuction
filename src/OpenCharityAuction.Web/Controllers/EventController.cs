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
        
        public IActionResult Index(string successMessage = null)
        {
            ViewData["SuccessMessage"] = successMessage;
            return View("Index");
        }

        public IActionResult AddEvent(string errorMessage = null)
        {
            ViewData["ErrorMessage"] = errorMessage;
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
                return RedirectToAction("Index", "Event", new { successMessage = "Event Added" });
            }
            return View("AddEvent", model);

        }

        public async Task<IActionResult> EditEvent(int id, string errorMessage = null)
        {
            Event dbEvent = new Event();
            await AuctionService.GetEventById(id, ev => dbEvent = ev);
            EditEventViewModel editEventVm = new EditEventViewModel()
            {
                Id = id,
                EventName = dbEvent.EventName,
                EventDate = dbEvent.EventDate
            };
            ViewData["ErrorMessage"] = errorMessage;
            return View("EditEvent", editEventVm);
        }

        public IActionResult SearchEvent()
        {
            return View("SearchEvent");
        }

        public IActionResult SelectCurrentEvent(string errorMessage = null)
        {
            ViewData["ErrorMessage"] = errorMessage;
            return View("SelectCurrentEvent");
        }

        [HttpPost]
        public async Task<IActionResult> SelectCurrentEvent(int eventId)
        {
            await UserService.UpdateCurrentEventForUser(eventId);
            return RedirectToAction("Index", "Event", new { successMessage = "Active Event Changed" });
        }
    }
}
