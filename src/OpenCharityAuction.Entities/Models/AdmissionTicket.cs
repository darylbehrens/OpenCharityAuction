using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    public class AdmissionTicket
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
