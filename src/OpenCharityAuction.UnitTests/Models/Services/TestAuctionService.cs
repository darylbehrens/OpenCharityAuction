using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web.Models.Interfaces;
using OpenCharityAuction.Web.ViewModels;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    public class TestAuctionService : IAuctionService
    {
        public Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            newEvent.Id = 1;
            newEvent.CreateDate = DateTime.Now;
            return Task.Run(() => callback(newEvent));
        }

        public Task GetAllEvents(Action<List<Event>> callback)
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    EventName = "TestEvent"
                }
            };

            return Task.Run(() => callback(events));
        }
    }
}
