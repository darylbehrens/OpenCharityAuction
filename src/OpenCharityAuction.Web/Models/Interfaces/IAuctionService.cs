using OpenCharityAuction.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Interfaces
{
    public interface IAuctionService
    {
        Task AddEvent(Event newEvent, Action<Event> callback = null);

        Task GetEvents(Action<List<Event>> callback, string query = null);

        Task GetEventById(int id, Action<Event> callback);

        Task UpdateEvent(Event ev);

        Task AddAdmissionTicket(AdmissionTicket newAdmissionTicket, Action<AdmissionTicket> callback = null);

        Task GetMeals(Action<List<Meal>> callback, string nameFilter = null);
        
        Task AddMeal(Meal newMeal, Action<Meal> callback = null);

        Task UpdateMeal(Meal meal);

        Task GetMealById(int id, Action<Meal> callback);
    }
}
