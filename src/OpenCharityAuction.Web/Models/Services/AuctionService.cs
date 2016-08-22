using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenCharityAuction.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace OpenCharityAuction.Web.Models.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly Data.AuctionContext AuctionContext;

        public AuctionService(Data.AuctionContext context)
        {
            AuctionContext = context;
        }

        public async Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            newEvent.CreateDate = DateTime.UtcNow.Date;
            AuctionContext.Events.Add(newEvent);
            await AuctionContext.SaveChangesAsync();

            // Send CallBack if not null
            callback?.Invoke(newEvent);
        }

        public async Task GetAllEvents(Action<List<Event>> callback)
        {
            var events = await Task.Run(() => AuctionContext.Events.ToList());
            callback(events);

        }

        public async Task GetEventById(int id, Action<Event> callback)
        {
            callback(await AuctionContext.Events.Where(x => x.Id == id).FirstOrDefaultAsync());
        }
    }
}
