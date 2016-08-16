using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.ViewModels;
using OpenCharityAuction.Web.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly AuctionContext Context;

        public EventController(AuctionContext context)
        {
            Context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEvent(AddEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mod = model;
                return RedirectToAction("Index", "Event");
            }
            return View(model);
       
        }
    }
}
