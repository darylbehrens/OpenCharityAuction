using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    public class BidderAdmissionTicket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int BidderId { get; set; }

        [Required]
        public int AdmissionTicketId { get; set; }

        public virtual Bidder Bidder { get; set; }

        public virtual AdmissionTicket AdmissionTicket { get; set; }
    }
}
