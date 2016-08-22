using OpenCharityAuction.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.ViewModels
{
    public class SelectCurrentEventViewModel
    {
        public int? SelectedEventId { get; set; }

        public List<Event> Events { get; set; }
    }
}
