using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    /// <summary>
    /// A Bidder is an Attendee at the Event that will be Bidding On Items
    /// 
    /// </summary>
    public class Bidder
    {

        public int Id { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public int? BidderNumber { get; set; } // In case user does not want to use Id.  If null Id Will Be Used

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int? ReservedTableId { get; set; }

        public System.DateTime CreateDate { get; set; }

        public System.DateTime UpdateDate { get; set; }
    }
}
