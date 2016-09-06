using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.Data;
using OpenCharityAuction.Web.Models.Services;
using OpenCharityAuction.Web.Models.Interfaces;
using OpenCharityAuction.Entities.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService UserService;
        private readonly IAuctionService AuctionService;

        public HomeController(IUserService userService, IAuctionService auctionService)
        {
            UserService = userService;
            AuctionService = auctionService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            if (UserService.GetCurrentUsersActiveEvent().Result.HasValue)
            {
                return View("Index");
            }
            else
            {
                List<Event> events = new List<Event>();
                await AuctionService.GetEvents(ev => events = ev);
                if (events.Count == 0)
                {
                    return RedirectToAction("AddEvent", "Event");
                }
                else
                {
                    return RedirectToAction("SelectCurrentEvent", "Event");
                }

            }
        }
    }
}
