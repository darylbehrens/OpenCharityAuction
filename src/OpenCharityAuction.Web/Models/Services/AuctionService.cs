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
            // Dependency Injection Of Context
            AuctionContext = context;
        }

        public async Task AddAdmissionTicket(AdmissionTicket newAdmissionTicket, Action<AdmissionTicket> callback = null)
        {
            // Save New Admission Ticket
            newAdmissionTicket.CreateDate = DateTime.UtcNow.Date;
            newAdmissionTicket.ModifiedDate = DateTime.UtcNow.Date;
            AuctionContext.AdmissionTickets.Add(newAdmissionTicket);
            await AuctionContext.SaveChangesAsync();

            // Send Callback If Not Null
            callback?.Invoke(newAdmissionTicket);
        }

        public async Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            // Save New Event
            newEvent.CreateDate = DateTime.UtcNow.Date;
            AuctionContext.Events.Add(newEvent);
            await AuctionContext.SaveChangesAsync();

            // Send CallBack if not null
            callback?.Invoke(newEvent);
        }
        
        public async Task GetAllEvents(Action<List<Event>> callback)
        {
            // Get and return all events
            var events = await Task.Run(() => AuctionContext.Events.ToList());
            callback(events);

        }

        public async Task GetEventById(int id, Action<Event> callback)
        {
            // Return Event By Id Number
            callback(await AuctionContext.Events.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        public async Task AddMeal(Meal newMeal, Action<Meal> callback = null)
        {
            newMeal.CreateDate = DateTime.UtcNow;
            AuctionContext.Meals.Add(newMeal);
            await AuctionContext.SaveChangesAsync();
            callback(newMeal);
        }

        public Task GetMeals(Action<List<Meal>> callback)
        {
            throw new NotImplementedException();
        }
    }
}
