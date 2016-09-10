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
        public async Task AddAdmissionTicket(AdmissionTicket newAdmissionTicket, Action<AdmissionTicket> callback = null)
        {
            await Task.Run(() => { callback?.Invoke(new AdmissionTicket()); });
        }

        public Task AddEvent(Event newEvent, Action<Event> callback = null)
        {
            newEvent.Id = 1;
            newEvent.CreateDate = DateTime.Now;
            return Task.Run(() => callback(newEvent));
        }

        public Task GetEvents(Action<List<Event>> callback, string query = null)
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

        public Task GetEventById(int id, Action<Event> callback)
        {
            return Task.Run(() => { return new List<Event>(); });
        }

        public Task GetMeals(Action<List<Meal>> callback)
        {
            var meals = new List<Meal>()
            {
                new Meal()
                {
                    Name = "TEST",
                    Description = "Yummy Food"
                }
            };

            return Task.Run(() => callback(meals));
        }

        public Task AddMeal(Meal newMeal, Action<Meal> callback = null)
        {
            return Task.Run(() => callback?.Invoke(new Meal()));
        }

        public Task GetMeals(Action<List<Meal>> callback, string nameFilter = null)
        {
            return Task.Run(() => callback(new List<Meal>()));
        }

        public Task UpdateMeal(Meal meal)
        {
            return Task.Run(() => { });
        }

        public Task GetMealById(int id, Action<Meal> callback)
        {
            return Task.Run(() => callback(new Meal()
            {
                Id = id,
                Name = "Turkey",
                Description = "Delicious Turkey",
                CreateDate = DateTime.Now,
                CreatedBy = "DARYL",
                EventId = 1
            }));
        }

        public Task UpdateEvent(Event ev)
        {
            return Task.Run(() => { });
        }
    }
}
