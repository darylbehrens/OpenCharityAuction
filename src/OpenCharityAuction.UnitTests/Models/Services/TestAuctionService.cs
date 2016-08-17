using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCharityAuction.Entities.Models;
using OpenCharityAuction.Web.Models.Interfaces;

namespace OpenCharityAuction.UnitTests.Models.Services
{
    public class TestAuctionService : IAuctionService
    {
        public Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            newEvent.Id = 1;
            return Task.Run(() => callback(newEvent));
        }
    }
}
