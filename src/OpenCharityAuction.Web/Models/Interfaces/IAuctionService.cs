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

        Task GetAllEvents(Action<List<Event>> callback);

        Task GetEventById(int id, Action<Event> callback);

        Task AddAdmissionTicket(AdmissionTicket newAdmissionTicket, Action<AdmissionTicket> callback = null);

        Task GetMeals(Action<List<Meal>> callback);

        Task AddMeal(Meal newMeal, Action<Meal> callback = null);
    }
}
