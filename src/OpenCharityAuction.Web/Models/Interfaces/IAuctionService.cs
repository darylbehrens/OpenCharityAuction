using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Interfaces
{
    public interface IAuctionService
    {
        void AddEvent(Entities.Models.Event newEvent, Action<Entities.Models.Event> callback = null);
    }
}
