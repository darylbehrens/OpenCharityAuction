using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate {get; set;}
    }
}
