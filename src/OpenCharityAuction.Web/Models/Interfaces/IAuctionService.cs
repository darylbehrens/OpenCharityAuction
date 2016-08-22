using OpenCharityAuction.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Interfaces
{
    public interface IAuctionService
    {
        Task AddEvent(Entities.Models.Event newEvent, Action<Event> callback = null);

        Task GetAllEvents(Action<List<Event>> callback);
    }
}
