using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenCharityAuction.Web.Models.Interfaces;
using OpenCharityAuction.Entities.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenCharityAuction.Web.Api
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IAuctionService AuctionService;
        private readonly IUserService UserService;

        public EventsController(IAuctionService auctionService, IUserService userService)
        {
            AuctionService = auctionService;
            UserService = userService;
        }

        // GET: api/values/{serach query}
        [HttpGet]
        public async Task<IEnumerable<Event>> Get(string query)
        {
            List<Event> eventList = new List<Event>();
            await AuctionService.GetEvents(events => eventList = events, query);
            return eventList;
        }
    }
}
