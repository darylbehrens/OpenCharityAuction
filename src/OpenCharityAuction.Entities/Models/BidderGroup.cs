using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    public class BidderGroup
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PrimaryPhone { get; set; }

        public string SecondaryPhone { get; set; }

        public string Email { get; set; }


    }
}
