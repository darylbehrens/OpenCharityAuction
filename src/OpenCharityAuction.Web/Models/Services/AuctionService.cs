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
        
        public async Task GetEvents(Action<List<Event>> callback, string query = null)
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
            callback?.Invoke(newMeal);
        }

        public async Task GetMeals(Action<List<Meal>> callback, string nameFilter = null)
        {
            var meals = await AuctionContext.Meals.ToListAsync();
            if (nameFilter != null)
            {
                meals = meals.Where(x => x.Name.StartsWith(nameFilter)).ToList();
            }
            callback(meals);
        }

        public async Task UpdateMeal(Meal meal)
        {
            var mealToUpdate = await AuctionContext.Meals.Where(x => x.Id == meal.Id).FirstOrDefaultAsync();
            mealToUpdate.Name = meal.Name;
            mealToUpdate.Description = meal.Description;
            AuctionContext.Entry(mealToUpdate).State = EntityState.Modified;
            await AuctionContext.SaveChangesAsync();
        }

        public async Task GetMealById(int id, Action<Meal> callback)
        {
            var meal = await AuctionContext.Meals.Where(x => x.Id == id).FirstOrDefaultAsync();
            callback(meal);
        }
    }
}
