using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    [DebuggerNonUserCode]
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate {get; set;}

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }
    }
}
